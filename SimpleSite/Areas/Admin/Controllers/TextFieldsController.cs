using Microsoft.AspNetCore.Mvc;
using SimpleSite.Domain;
using SimpleSite.Domain.Entities;
using SimpleSite.Service;

namespace SimpleSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;

        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var textField = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(textField);
        }

        [HttpPost]
        public IActionResult Edit(TextField textField)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(textField);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(textField);
        }
    }
}