using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class SepetController : Controller
    {
        // GET: Sepet
        OyuncakciEntities db = new OyuncakciEntities();
        public ActionResult Index()
        {
            var model = this.db.SEPETIM.Where(x => x.USERID == 1).ToList();
                        
            return View(model);
        }

        [HttpPost]
        public ActionResult SepetEke(int id)
        {
            var urun = this.db.URUN.Find(id);
            if (urun != null)
            {
                int userId = 1;//int.Parse(Request.Cookies["userId"].Value);
                var sepetim = this.db.SEPETLER.Find(userId);
                if (sepetim == null)
                {
                    SEPETLER sptlr =new SEPETLER();
                    sptlr.USERID = userId;
                    db.SEPETLER.Add(sptlr);
                    db.SaveChanges();
                }
                sepetim = this.db.SEPETLER.Find(userId);
                SEPETIM spt =new SEPETIM()
                                  {
                                    SEPETID  = sepetim.ID,
                                      USERID = 1,
                                     URUN =urun.ID.ToString()
                                  };
                this.db.SEPETIM.Add(spt);
                this.db.SaveChanges();
                var sayim = this.db.SEPETIM.Where(x => x.USERID == userId);
                return Json(new { success = true, message = "Sepete eklendi", adet= sayim.Count()}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Bir hata oluştu" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult sepetSayim()
        {
            var sayim = this.db.SEPETIM.Where(x => x.USERID == 1);
            if(sayim!=null) return Json(new { success = true,  adet = sayim.Count() }, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(new { success = false, message = "Bir hata oluştu" }, JsonRequestBehavior.AllowGet);
            }
   
        }
        public ActionResult SepetUrunSil(int id)
        {
            if (id>0)
            {
                var model = this.db.SEPETIM.Find(id);
                this.db.SEPETIM.Remove(model);
                this.db.SaveChanges();
                return Json(new { success = true, message = "Silindi." }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Bir hata oluştu" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SepetBosalt(int id)
        {
            if (id > 0)
            {
                var model = this.db.SEPETLER.Find(id);
                var sepetIcerik = this.db.SEPETIM.Where(m => m.ID.Equals(id));
                foreach (var urun in sepetIcerik)
                {
                    this.db.SEPETIM.Remove(urun);
                    this.db.SaveChanges();
                }
                return Json(new { success = true, message = "Sepet boşaltıldı." }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Bir hata oluştu" }, JsonRequestBehavior.AllowGet);
        }
    }
}