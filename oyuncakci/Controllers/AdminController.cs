using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using System.Data.Entity;
    using System.Web.Services.Description;

    using oyuncakci.Models;

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var aa = this.Siparisler();
            return View();
        }

        public JsonResult Siparisler()
        {
            OyuncakciEntities db = new OyuncakciEntities();

           dynamic sepet = db.Database.SqlQuery<AdminSparisListe>("SELECT  SEPETIM.SEPETID, (USERS.ADİ+' '+USERS.SOYADİ) AS KULLANICI,COUNT(SEPETIM.URUN) AS ADET, SUM(URUN.FIYAT) AS TOPLAMFIYAT FROM SEPETIM "+
          "  INNER JOIN SEPETLER ON SEPETLER.ID = SEPETIM.SEPETID"+
           " INNER JOIN USERS ON USERS.ID = SEPETLER.USERID" +
         "   INNER JOIN URUN ON URUN.ID = SEPETIM.URUN" +
           " GROUP BY SEPETIM.SEPETID, USERS.ADİ, USERS.SOYADİ ORDER BY USERS.ADİ")
                .ToList();
         

            //var sepet = db.SEPETIM.Join(
            //db.SEPETLER.Join(
            //    db.USERS,
            //    usr => usr.ID,
            //    sprs1 => sprs1.ID,
            //    (usr, sprs1) => new { user = sprs1, sepet1 = usr }),
            //spt => spt.SEPETID,
            //sprs => sprs.sepet1.ID,
            //(sprs, spt) => new { siparis = sprs, sepet = spt }).Join(
            //    db.URUN,
            //    urnid => urnid.siparis.URUN,
            //    urn => urn.ID,
            //    (urnid, urn) => new { genel = urnid, urunler = urn })
            //.Where(x => x.genel.sepet.sepet1.TAMAMLANDIMI != true).Select(
            //    x => new
            //    {
            //        x.genel.siparis.ID,
            //        x.genel.siparis.SEPETID,
            //        x.genel.siparis.URUN,
            //        x.genel.sepet.sepet1.USERID,
            //        x.genel.sepet.user.ADİ,
            //        x.urunler.ADI
            //    }).GroupBy(x => new { x.ADİ }).ToList();

            return Json(new { success = true, sepetler = sepet }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SiparisOnayla(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var siparis = db.SIPARISLERIM.Find(id);
            siparis.ONAYLANDIMI = true;
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SiparisIptal(int id)
        {
            OyuncakciEntities db = new OyuncakciEntities();
            var siparis = db.SIPARISLERIM.Find(id);
            siparis.IPTAL = true;
            db.SaveChanges();
            return Json(new { success = true, message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
    }


}