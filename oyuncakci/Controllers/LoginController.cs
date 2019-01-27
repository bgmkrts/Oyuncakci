using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oyuncakci.Controllers
{
    using System.Net;
    using System.Net.Mail;

    using oyuncakci.Models;

    public class LoginController : Controller
    {
        // GET: Login
        OyuncakciEntities db = new OyuncakciEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(USERS usr)
        {
            OyuncakciEntities db = new OyuncakciEntities();

            var model = db.USERS.Where(x => x.E_MAİL.Equals(usr.E_MAİL) && x.SIFRE.Equals(usr.SIFRE)).FirstOrDefault();
            if (model != null)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult SifremiUnuttum()
        {
            return this.View();
        }


        [HttpPost]// async System.Threading.Tasks.Task<ActionResult> 
        public ActionResult SifremiUnuttum(string email)
        {
            OyuncakciEntities db = new OyuncakciEntities();

            var model = db.USERS.Where(x => x.E_MAİL.Equals(email)).FirstOrDefault();
            if (model != null)
            {
                Random rnd = new Random();
                int kod = rnd.Next(99999, 1000000);
                SIFREMIYENILE sfr = new SIFREMIYENILE()
                {
                    USERID = model.ID,
                    YENILEMEKODU = kod.ToString()
                };
                db.SIFREMIYENILE.Add(sfr);
                db.SaveChanges();

                //var body = "<p>Yenileme kodu </p><p>{0}</p>";
                //var message = new MailMessage();
                //message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                //message.Subject = "Your email subject";
                //message.Body = string.Format(body, kod);
                //message.IsBodyHtml = true;

                //using (var smtp = new SmtpClient())
                //{
                //    var credential = new NetworkCredential
                //    {
                //        UserName = "user@outlook.com",  // replace with valid value
                //        Password = "password"  // replace with valid value
                //    };
                //    smtp.Credentials = credential;
                //    smtp.Host = "smtp-mail.outlook.com";
                //    smtp.Port = 587;
                //    smtp.EnableSsl = true;
                //    await smtp.SendMailAsync(message);
                  
                //}
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpGet]
        public ActionResult SifremiYenile()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult SifremiYenile(string email,string sifre,string kod)
        {

            var model = db.USERS.Where(x => x.E_MAİL.Equals(email)).FirstOrDefault();
            if (model != null)
            {
                var yenilemeKontrol = this.db.SIFREMIYENILE.FirstOrDefault(x => x.USERID == model.ID && x.YENILEMEKODU ==kod);
                if (yenilemeKontrol != null)
                {
                    USERS usr = new USERS();
                    usr = this.db.USERS.Find(model.ID);
                    usr.SIFRE = sifre;
                    db.Entry(usr);
                    return RedirectToAction("Index", "Login"); // Şifre Değiştirme başarılı.
                }
                return RedirectToAction("SifremiYenile", "Login");// Kod yanlis 
            }
            else
            {
                return RedirectToAction("SifremiYenile", "Login");// email yanlış
            }
        }
    }
}