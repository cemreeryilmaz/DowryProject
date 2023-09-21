using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        IProductService _productService;

        public ProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
