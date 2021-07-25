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

        public ActionResult Details(int id)
        {
            var svc = CreateVegetableService();
            var model = svc.GetVegetableById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateVegetableService();
            var detail = service.GetVegetableById(id);
            var model =
                new VegetableEdit
                {
                    VegetableId = detail.VegetableId,
                    Name = detail.Name,
                    ShelfLifeInDays = detail.ShelfLifeInDays,
                    AmountInOunces = detail.AmountInOunces,
                    Count = detail.Count
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VegetableEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VegetableId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVegetableService();

            if (service.UpdateVegetable(model))
            {
                TempData["SaveResult"] = "Your vegetable was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Vegetable could not be updated.");

            return View();
        }
        private VegetableService CreateVegetableService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VegetableService(userId);
            return service;
        }

    }
}
