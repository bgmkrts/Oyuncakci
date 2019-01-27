using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        public ActionResult Index()
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.USERS.ToList();
            return View(model);
        }
    }
}