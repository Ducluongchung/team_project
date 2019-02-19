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
using Microsoft.AspNet.Identity;

namespace EcommerceCore.Website.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IManufacturerService _manufacturerService;
        public HomeController
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
        
        public async Task<ActionResult> ListProduct()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            // Get user name
            ViewBag.UserName = User.Identity.GetUserName();
            var categories = await _categoryService.GetAll();
            var suppliers = await _supplierService.GetAll();
            var manufacturers = await _manufacturerService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}