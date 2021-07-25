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
    public class FruitController : Controller
    {
        // GET: Fruit
        public ActionResult Index()// Displays all fruits for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FruitService(userId);
            var model = service.GetFruits();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FruitCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFruitService();

            if (service.CreateFruit(model))
            {
                TempData["SaveResult"] = "Your fruit was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Fruit could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateFruitService();
            var model = svc.GetFruitById(id);

            return View(model);
        }

        private FruitService CreateFruitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FruitService(userId);
            return service;
        }
    }
}