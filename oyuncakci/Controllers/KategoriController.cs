using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using oyuncakci.Models;

    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult KategoriListele()
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var liste = db.KATEGORI.ToList();
            if (liste != null)
            {
                return Json(new { success = true, data = liste }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ALtKategoriListele(int kategoriId)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var liste = db.ALTKATEGORI.Where(x => x.KATEGORIID == kategoriId).ToList();
            if (liste != null)
            {
                return Json(new { success = true, data = liste }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult KetegoriEkle(string adi)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            KATEGORI ktgr = new KATEGORI()
            {
                ADI = adi
            };
            db.KATEGORI.Add(ktgr);
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult KetegoriSil(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.KATEGORI.Find(id);
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AltKetegoriEkle(ALTKATEGORI altktgr)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            ALTKATEGORI ktgr = new ALTKATEGORI()
            {
                ADI = altktgr.ADI,
                KATEGORIID = altktgr.ID
            };
            db.ALTKATEGORI.Add(ktgr);
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AltKetegoriSil(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var model = db.ALTKATEGORI.Find(id);
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
    }
}