using GrocerySaver.Models;
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
        public ActionResult Index()
        {
            var model = new BeverageListItem[0];
            return View(model);
        }
    }
}