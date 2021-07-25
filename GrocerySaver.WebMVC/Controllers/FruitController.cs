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
        public ActionResult Edit(int id)
        {
            var service = CreateFruitService();
            var detail = service.GetFruitById(id);
            var model =
                new FruitEdit
                {
                    FruitId = detail.FruitId,
                    Name = detail.Name,
                    ShelfLifeInDays = detail.ShelfLifeInDays,
                    AmountInOunces = detail.AmountInOunces,
                    Count = detail.Count
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FruitEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FruitId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFruitService();

            if (service.UpdateFruit(model))
            {
                TempData["SaveResult"] = "Your fruit was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Fruit could not be updated.");

            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateFruitService();
            var model = svc.GetFruitById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFruitService();
            service.DeleteFruit(id);
            TempData["SaveResult"] = "Your fruit was deleted";
            return RedirectToAction("Index");
        }
        private FruitService CreateFruitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FruitService(userId);
            return service;
        }
    }
}