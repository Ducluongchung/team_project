
$(document).ready(function () {
    LoadData();
    $(document).on("click", "#Create", function () {
        $('#myModal').modal('show');
        $('#UpdateProduct').hide();
        $('.CreateProductBy').hide();
        $('.CreateProduct').show();
        $('.sua').hide();
        $('.them').show();
    });
    CKEDITOR.replace("Description");
    CKEDITOR.replace("ShortDescription");
  
    $(document).on("click", ".CreateProduct", function () {
        var Description = CKEDITOR.instances["Description"].getData();
        var ShortDescription = CKEDITOR.instances["ShortDescription"].getData();
        var res = Validate();
        if (!res) {
            $('#myModal').modal('show');
            return false;
        }
        else {
            var obj =
            {
                UrlName: $("#UrlName").val(),
                Title: $("#Title").val(),
                Price: $("#Price").val(),
                View: $("#View").val(),
                Sku: $("#Sku").val(),
                ExpirationDate: $("#ExpirationDate").val(),
                PublicationDate: $("#PublicationDate").val(),
                Keyword: $("#Keyword").val(),
                Description: Description,
                ShortDescription: ShortDescription,
                Weight: $("#Weight").val(),
                Height: $("#Height").val(),
                Depth: $("#Depth").val(),
                CategoryId: $(".CategoryId").val(),
                SupplierId: $(".SupplierId").val(),
                ManufacturerId: $(".ManufacturerId").val(),
                CreatedBy: $("#CreatedBy").val()
            };
            $.ajax({
                url: "/Product/Create",
                data: JSON.stringify(obj),
                contentType: "application/json;charset=utf-8",
                type: "POST",
                success: function (result) {
                    $('#myModal').modal('hide');
                    LoadData();

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
        LoadData();
    });

});
//
$(document).on("click", ".Huy", function () {
    $('#myModal').modal('hide');
});
//
$(document).on('click', "a[data-role=status]", function () {
    var id = $(this).data('id');
    $.ajax({
        url: "/Product/UpdateStatus/" + id,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        success: function (result) {
            LoadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    LoadData();
});
//
$(document).on('click', "a[data-role=edit]", function () {
    var id = $(this).data('id');
    $('.CreateProductBy').show();
    $('#UpdateProduct').show();
    $('.CreateProduct').hide();
    $('.them').hide();
    $('.sua').show();
    $.ajax({
        url: "/Product/Edit/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        success: function (result) {
            $('#myModal').modal('show'),
                $("#Id").val(result.Id)
            $("#UrlName").val(result.UrlName),
                $("#Title").val(result.Title),
                $("#Price").val(result.Price),
                $("#View").val(result.View),
                $("#Sku").val(result.Sku),
                $("#Keyword").val(result.Keyword),
                CKEDITOR.instances['Description'].setData(result.Description),
                CKEDITOR.instances['ShortDescription'].setData(result.ShortDescription),
                $("#Weight").val(result.Weight),
                $("#Height").val(result.Height),
                $("#Depth").val(result.Depth),
                $("#SupplierId").val(result.SupplierId),
                $("#ManufacturerId").val(result.ManufacturerId),
                $("#CreatedBy").val(result.CreatedBy)
            var dt = new Date(parseInt(result.PublicationDate.replace('/Date(', '')))
            var PublicationDate = AddLeadingZeros(dt.getFullYear(), 4) + '-' +
                AddLeadingZeros(dt.getMonth() + 1, 2) + '-' +
                AddLeadingZeros(dt.getDate(), 2);
            var dt1 = new Date(parseInt(result.ExpirationDate.replace('/Date(', '')))
            var ExpirationDate = AddLeadingZeros(dt1.getFullYear(), 4) + '-' +
                AddLeadingZeros(dt1.getMonth() + 1, 2) + '-' +
                AddLeadingZeros(dt1.getDate(), 2)
            $("#PublicationDate").val(PublicationDate)
            $("#ExpirationDate").val(ExpirationDate)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});
//
$(document).on( "click", "#UpdateProduct", function () {
    var res = Validate();
    if (!res) {
        return false;
    }
    else {
        var Description = CKEDITOR.instances["Description"].getData();
        var ShortDescription = CKEDITOR.instances["ShortDescription"].getData();
        var obj =
        {
            Id: $("#Id").val(),
            UrlName: $("#UrlName").val(),
            Title: $("#Title").val(),
            Price: $("#Price").val(),
            View: $("#View").val(),
            Sku: $("#Sku").val(),
            ExpirationDate: $("#ExpirationDate").val(),
            PublicationDate: $("#PublicationDate").val(),
            Keyword: $("#Keyword").val(),
            Description: Description,
            ShortDescription: ShortDescription,
            Weight: $("#Weight").val(),
            Height: $("#Height").val(),
            Depth: $("#Depth").val(),
            CategoryId: $("#CategoryId").val(),
            SupplierId: $("#SupplierId").val(),
            ManufacturerId: $("#ManufacturerId").val(),
            CreatedBy: $("#CreatedBy").val()
        };
        $.ajax({
            url: "/Product/Edit",
            data: JSON.stringify(obj),
            contentType: "application/json;charset=utf-8",
            type: "POST",
            success: function (result) {
                $('#myModal').modal('hide');
                LoadData();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        $('#myModal').modal('hide');
    };
});
//
$(document).on('click', "a[data-role=delete]", function () {
    var id = $(this).data('id');
    var ans = confirm("Bạn có muốn xóa không");
    if (ans) {
        $.ajax({
            url: "/Product/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            success: function (result) {
                LoadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
});
//
function Validate() {
    var validate = true;
    var Title = $("#Title").val();
    var Price = $("#Price").val();
    var PublicationDate = $("#PublicationDate").val();
    var ExpirationDate = $("#ExpirationDate").val()
    if (Title == "") {
        $("#Title").css("border-color", "red");
        validate = false;
    }
    else {
        $("#Title").css("border-color", "#d2d6de");
    }

    if (Price == "") {
        $("#Price").css("border-color", "red");
        validate = false;
    } else { $("#Price").css("border-color", "#d2d6de"); }
    if (PublicationDate == "") {
        $("#PublicationDate").css("border-color", "red");
        validate = false;
    }
    else { $("#ExpirationDate").css("border-color", "#d2d6de"); }
    if (ExpirationDate == "") {
        $("#ExpirationDate").css("border-color", "red");
        validate = false;
    }
    else { $("#PublicationDate").css("border-color", "#d2d6de"); }
    return validate;
}
function AddLeadingZeros(number, size) {
    var s = "0000" + number;
    return s.substr(s.length - size);
}
function LoadData() {
    var index = 1;
    $.ajax({
        url: "/Product/Index",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<tr>';
                html += '<td>' + index + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.SupplierName + '</td>';
                html += '<td> <span class = "label label-success"> ' + item.Price + ' </span></td>';
                var dt2 = new Date(parseInt(item.PublicationDate.replace('/Date(', '')))
                var date = AddLeadingZeros(dt2.getDate(), 2) + '/' +
                    AddLeadingZeros(dt2.getMonth() + 1, 2) + '/' +
                    AddLeadingZeros(dt2.getFullYear(), 4)
                html += '<td> <span class = "label label-info"> ' + date + ' </span></td>';
                html += '<td> <span class = "label label-info"> ' + item.View + ' </span></td>';
                var status = item.Status;
                if (status === 1) {
                    status = "Hiển thị";
                    html += '<td class="text-center"> <a class = "label label-success" data-role="status" data-id = ' + item.Id + '> ' + status + ' </a></td>';
                }
                else {
                    status = "Ẩn";
                    html += '<td class="text-center" > <a class = "label label-danger" data-role="status" data-id = ' + item.Id + '> ' + status + ' </a></td>';
                }
                html += '<td> <div class="activity text-center"> <a class="delete btn btn-danger" data-role="delete" data-id = ' + item.Id + ' > <i class="fas fa-trash" title="xóa"> </i> Xóa </a > <a class="edit btn btn-info" style="margin-left:4px" data-role="edit" data-id = ' + item.Id + '><i class="fas fa-edit" title="sửa"></i> Sửa</a></div ></td>';
                html += '</tr>';
                index++;
            });
            console.log(data);
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
