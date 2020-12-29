using Microsoft.AspNetCore.Mvc;

namespace SimpleSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}