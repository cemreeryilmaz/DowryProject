using Business.Abstract;
using Business.Concrete;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using DowryWebUI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace DowryWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult AdminIndex()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetProductDetails(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductAddViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    ProductName = model.Product.ProductName,
                    UnitPrice = model.Product.UnitPrice,
                    PurchaseDate = model.Product.PurchaseDate,
                    CategoryId = model.Product.CategoryId,
                };

                if (file !=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                       await file.CopyToAsync(stream);
                    }
                }
                    TempData["message"] = _productService.Add(entity).Message;
            }
            return RedirectToAction("AdminIndex");
        }

        [HttpGet]
        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId).Data,
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Product product,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(product.ProductId);

                entity.Data.ProductName = product.ProductName;
                entity.Data.UnitPrice = product.UnitPrice;
                entity.Data.ImageUrl = product.ImageUrl;
                entity.Data.PurchaseDate = DateTime.Now;

                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    product.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                TempData["message"] = _productService.Update(product).Message;
            }

            return RedirectToAction("AdminIndex");

        }

        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity.Data);
            }

            return RedirectToAction("AdminIndex");

        }

    }
}