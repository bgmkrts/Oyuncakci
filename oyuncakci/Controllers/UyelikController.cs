using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class UyelikController : Controller
    {
        // GET: Uyelik
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUye(USER usr)
        {
            if (usr.ID == 0)
            {
                using (OyuncakciEntities db = new OyuncakciEntities())
                {
                    db.USER.Add(usr);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index","Uyelik");
            }
        }
    }
}