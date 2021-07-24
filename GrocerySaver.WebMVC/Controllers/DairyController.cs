using GrocerySaver.Models;
using GrocerySaver.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrocerySaver.WebMVC.Controllers
{
    [Authorize]
    public class DairyController : Controller
    {
        // GET: Dairy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DairyService(userId);
            var model = service.GetDairies();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DairyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDairyService();

            if (service.CreateDairy(model))
            {
                TempData["SaveResult"] = "Your dairy item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Dairy item could not be created.");

            return View(model);

        }

        private DairyService CreateDairyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DairyService(userId);
            return service;
        }
    }
}