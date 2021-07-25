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

        public ActionResult Details(int id)
        {
            var svc = CreateBeverageService();
            var model = svc.GetBeverageById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBeverageService();
            var detail = service.GetBeverageById(id);
            var model =
                new BeverageEdit
                {
                    BeverageId = detail.BeverageId,
                    Name = detail.Name,
                    ShelfLifeInDays = detail.ShelfLifeInDays,
                    AmountInOunces = detail.AmountInOunces,
                    Count = detail.Count
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeverageEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BeverageId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBeverageService();

            if(service.UpdateBeverage(model))
            {
                TempData["SaveResult"] = "Your beverage was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Beverage could not be updated.");

            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateBeverageService();
            var model = svc.GetBeverageById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBeverageService();
            service.DeleteBeverage(id);
            TempData["SaveResult"] = "Your beverage was deleted";
            return RedirectToAction("Index");
        }
        private BeverageService CreateBeverageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeverageService(userId);
            return service;
        }
    }
}