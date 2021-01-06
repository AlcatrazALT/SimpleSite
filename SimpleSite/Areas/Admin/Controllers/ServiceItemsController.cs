using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSite.Domain;
using SimpleSite.Domain.Entities;
using SimpleSite.Service;
using System;
using System.IO;

namespace SimpleSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
        {
            this.dataManager = dataManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var service = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(ServiceItem serviceItem, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    serviceItem.TitleImagePath = titleImageFile.FileName;
                    using var stream = new FileStream(
                        Path.Combine(webHostEnvironment.WebRootPath, "images/", titleImageFile.FileName),
                        FileMode.Create);

                    titleImageFile.CopyTo(stream);
                }
                dataManager.ServiceItems.SaveServiceItem(serviceItem);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(serviceItem);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}