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
    public class MeatController : Controller
    {
        // GET: Meat
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MeatService(userId);
            var model = service.GetMeats();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeatCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateMeatService();

            if (service.CreateMeat(model))
            {
                TempData["SaveResult"] = "Your meat was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Meat could not be created.");

            return View(model);


        }

        public ActionResult Details(int id)
        {
            var svc = CreateMeatService();
            var model = svc.GetMeatById(id);

            return View(model);
        }

        private MeatService CreateMeatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MeatService(userId);
            return service;
        }
    }
}