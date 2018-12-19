using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.URUN.ToList();

            return View(model);
        }
    }
}