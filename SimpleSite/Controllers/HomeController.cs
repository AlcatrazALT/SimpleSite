using Microsoft.AspNetCore.Mvc;
using SimpleSite.Domain;

namespace SimpleSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var pageIndexTextField = dataManager.TextFields.GetTextFieldByCodeWord("PageIndex");
            return View(pageIndexTextField);
        }

        public IActionResult Contacts()
        {
            var pageContactsTextField = dataManager.TextFields.GetTextFieldByCodeWord("PageContacts");
            return View(pageContactsTextField);
        }
    }
}