using AutoMapper;
using EcommerceCore.Common.Filter;
using EcommerceCore.Domain.Entities;
using EcommerceCore.Domain.Enums;
using EcommerceCore.Services.Infrastructure.ViewModels;
using EcommerceCore.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EcommerceCore.Websites.Models;
using Microsoft.AspNet.Identity;

namespace EcommerceCore.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IManufacturerService _manufacturerService;

        public ProductController
        (   
            IProductService productService, ICategoryService categoryService,
            ISupplierService supplierService, IManufacturerService manufacturerService
        )
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _manufacturerService = manufacturerService;

        }

        [HandleError]
  
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetProductForDashboard();
            ViewBag.Products = products;
            return Json(products,JsonRequestBehavior.AllowGet);
        }

        // GET: Product/Create
        //[Authorize(Roles = "Admin")]
        public async Task<ViewResult> Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            // Get user name
            ViewBag.UserName = User.Identity.GetUserName();
            var categories    = await  _categoryService.GetAll();
            var suppliers      = await  _supplierService.GetAll();
            var manufacturers  = await  _manufacturerService.GetAll();
            var productStatus = await _productService.GetAll();
            ViewBag.CategoryId= new SelectList(categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        [ValidateModelStateFilter]
        [HttpPost]
        public async Task<ViewResult> Create( ProductViewModel productViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = Mapper.Map<Product>(productViewModel);

                    product.Status = CommonStatus.Active;
                    await _productService.CreateAsync(product, true);
                }
            }
            catch
            {

            }

            var categories = await _categoryService.GetAll();
            var suppliers = await _supplierService.GetAll();
            var manufacturers = await _manufacturerService.GetAll();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productViewModel.CategoryId);
            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name", productViewModel.ManufacturerId);
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name", productViewModel.SupplierId);
            return View();
        }

        // GET: Product/Edit/5
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await _productService.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            //var categories = await _categoryService.GetAll();
            //var suppliers = await _supplierService.GetAll();
            //var manufacturers = await _manufacturerService.GetAll();

            //ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);
            //ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name", product.ManufacturerId);
            //ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name", product.SupplierId);

            var productViewModel = Mapper.Map<ProductViewModel>(product);
            return Json(productViewModel, JsonRequestBehavior.AllowGet);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(Guid id)
        {
            Product product = await _productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            _productService.UpdateStatus(id);
                
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel productViewModel)
        {
            
                Product product = await _productService.Find(productViewModel.Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                Mapper.Map(productViewModel, product);
                product.UpdatedDate = DateTime.Now;
                await _productService.UpdateAsync(product, productViewModel.Id, true);
                return RedirectToAction("Index");
           
            var categories = await _categoryService.GetAll();
            var suppliers = await _supplierService.GetAll();
            var manufacturers = await _manufacturerService.GetAll();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productViewModel.CategoryId);
            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name", productViewModel.ManufacturerId);
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name", productViewModel.SupplierId);
            return View();
        }
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await _productService.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productViewModel = Mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }

        // GET: Product/Delete/5
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            var product = await _productService.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productViewModel = Mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var product = await _productService.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                await _productService.DeleteAsync(product, true);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


    }
}
