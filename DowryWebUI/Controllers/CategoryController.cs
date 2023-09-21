using Business.Abstract;
using DowryWebUI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult CategoryList()
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new CategoryAddViewModel
            {
                Category = new Category()
            };
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryAddViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryName = model.Category.CategoryName,
                    ImageUrl = model.Category.ImageUrl,
                };

                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                TempData["message"] = _categoryService.Add(entity).Message;
            }
            return RedirectToAction("CategoryList");
        }


        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var entity = _categoryService.GetByIdWithProducts((int)categoryId);

            var model = new CategoryUpdateViewModel
            {
                Category = _categoryService.GetByIdWithProducts(categoryId).Data,
                Products = entity.Data.Products.ToList()
            };
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetById(category.CategoryId);

                entity.Data.CategoryName = category.CategoryName;
                entity.Data.ImageUrl = category.ImageUrl;


                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    category.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                TempData["message"] = _categoryService.Update(category).Message;
            }

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);

            return Redirect("/admin/categories/" + categoryId);
        }
    }
}
