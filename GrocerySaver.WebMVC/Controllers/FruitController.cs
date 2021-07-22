using GrocerySaver.Models;
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
        public ActionResult Index()
        {
            var model = new FruitListItem[0];
            return View(model);
        }
    }
}