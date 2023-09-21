using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
