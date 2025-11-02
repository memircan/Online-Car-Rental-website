using Microsoft.AspNetCore.Mvc;

namespace AracKiralama.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}