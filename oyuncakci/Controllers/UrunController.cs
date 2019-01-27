using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.URUN.ToList();
            return View(model);
        }

        public ActionResult Ayrinti(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.URUN.Find(id);
            return this.View(model);
        }
        [HttpGet]
        public ActionResult UrunEkleGuncelle(int id)
        {
            OyuncakciEntities db =new OyuncakciEntities();
            if (id > 0)
            {
                var model = db.URUN.Find(id);
                return View(model);
            }
            else
            {
                return View(new URUN());
            }
        }
        [HttpPost]
        public JsonResult UrunEkleGuncelle(URUN urn)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            if (urn.ID > 0)
            {
                URUN u = new URUN()
                {
                    ADI = urn.ADI,
                    ALTKATEGORIID = urn.ALTKATEGORIID,
                    FIYAT = urn.FIYAT,
                    FOTO = urn.FOTO,
                    MARKAID = urn.MARKAID,
                    STOKSAYISI = urn.STOKSAYISI,
                    YASARALIKID = urn.YASARALIKID
                };
                db.Entry(u);
                db.SaveChanges();
                return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
            }
            else
            {


                URUN u = new URUN()
                {
                    ADI = urn.ADI,
                    ALTKATEGORIID = urn.ALTKATEGORIID,
                    FIYAT = urn.FIYAT,
                    FOTO = urn.FOTO,
                    MARKAID = urn.MARKAID,
                    STOKSAYISI = urn.STOKSAYISI,
                    YASARALIKID = urn.YASARALIKID
                };
                db.URUN.Add(u);
                db.SaveChanges();
                return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult UrunSil(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.URUN.Find(id);
            db.URUN.Remove(model);
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);

        }
    }
}