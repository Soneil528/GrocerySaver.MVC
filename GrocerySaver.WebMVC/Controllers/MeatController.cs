using GrocerySaver.Models;
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
            var model = new MeatListItem[0];
            return View(model);
        }
    }
}