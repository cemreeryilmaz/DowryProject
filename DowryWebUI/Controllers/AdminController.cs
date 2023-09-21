using Business.Abstract;
using DowryWebUI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
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
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);

        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
            }
            return RedirectToAction("ProductIndex");
        }
    }
}
