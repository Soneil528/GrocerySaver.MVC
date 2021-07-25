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

        public ActionResult Details(int id)
        {
            var svc = CreateDairyService();
            var model = svc.GetDairyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDairyService();
            var detail = service.GetDairyById(id);
            var model =
                new DairyEdit
                {
                    DairyId = detail.DairyId,
                    Name = detail.Name,
                    ShelfLifeInDays = detail.ShelfLifeInDays,
                    AmountInOunces = detail.AmountInOunces,
                    Count = detail.Count
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DairyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DairyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDairyService();

            if (service.UpdateDairy(model))
            {
                TempData["SaveResult"] = "Your dairy item was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Dairy item could not be updated.");

            return View();
        }
        private DairyService CreateDairyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DairyService(userId);
            return service;
        }
    }
}