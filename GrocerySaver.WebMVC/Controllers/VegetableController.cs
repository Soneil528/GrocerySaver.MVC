using GrocerySaver.Models;
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
        public ActionResult Index()
        {
            var model = new VegetableListItem[0];
            return View(model);
        }
    }
}