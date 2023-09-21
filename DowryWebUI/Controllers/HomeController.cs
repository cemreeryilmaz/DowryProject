using Business.Abstract;
using DowryWebUI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new AdminListViewModel()
            {
                Products = _productService.GetAll(),
                Categories = _categoryService.GetAll(),
            };

            return View(model);

            //var result = _productService.GetAll();
            //if (result.Success)
            //{

            //}

            //return View();
        }

        public IActionResult ProductIndex()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetProductDetails()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product()
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
            }
            return RedirectToAction("ProductIndex", new {area = "Administrator" });
        }
    }
}