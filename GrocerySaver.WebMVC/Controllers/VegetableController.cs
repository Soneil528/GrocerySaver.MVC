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
    public class VegetableController : Controller
    {
        // GET: Vegetable
        public ActionResult Index()// Displays all vegetables for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VegetableService(userId);
            var model = service.GetVegetables();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VegetableCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVegetableService();

            if (service.CreateVegetable(model))
            {
                TempData["SaveResult"] = "Your Vegetable was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Vegetable could not be created.");

            return View(model);

        }

        private VegetableService CreateVegetableService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VegetableService(userId);
            return service;
        }

    }
}
