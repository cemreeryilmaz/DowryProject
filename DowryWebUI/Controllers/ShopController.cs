using Microsoft.AspNetCore.Mvc;

namespace DowryWebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
