using GrocerySaver.Models;
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
            var model = new DairyListItem[0];
            return View(model);
        }
    }
}