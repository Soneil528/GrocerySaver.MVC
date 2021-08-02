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
    public class AllGroceriesController : Controller
    {
        // GET: AllGroceries
        public ActionResult Index()// Displays all groceries for the current user
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllGroceriesService(userId);
            var model = service.GetAllGroceries();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AllGroceriesCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAllGroceriesService();

            if (service.CreateAllGroceries(model))
            {
                return RedirectToAction("Index");
            };


            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateAllGroceriesService();
            var model = svc.GetAllGroceriesById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAllGroceriesService();
            var detail = service.GetAllGroceriesById(id);
            var model =
                new AllGroceriesEdit
                {
                    GroceryId = detail.GroceryId,
                    GroceryType = detail.GroceryType
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AllGroceriesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GroceryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAllGroceriesService();

            if (service.UpdateAllGroceries(model))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateAllGroceriesService();
            var model = svc.GetAllGroceriesById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAllGroceriesService();
            service.DeleteAllGroceries(id);
            return RedirectToAction("Index");
        }
        private AllGroceriesService CreateAllGroceriesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllGroceriesService(userId);
            return service;
        }
    }
}
