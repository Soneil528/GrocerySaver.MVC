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
    public class BeverageController : Controller
    {

        // GET: Beverage
        public ActionResult Index()// Displays all beverages for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeverageService(userId);
            var model = service.GetBeverages();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeverageCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBeverageService();

            if (service.CreateBeverage(model))
            {
                TempData["SaveResult"] = "Your beverage was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Beverage could not be created.");

            return View(model);

        }

        private BeverageService CreateBeverageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeverageService(userId);
            return service;
        }
    }
}