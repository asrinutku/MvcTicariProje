using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler cr)

        {
            c.Carilers.Add(cr);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult MusteriLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriLogin(Cariler cr)

        {
            var auth = c.Carilers.FirstOrDefault(x => x.CariMail == cr.CariMail && x.CariPassw == cr.CariPassw);
            
            if (auth != null)
            {
                FormsAuthentication.SetAuthCookie(auth.CariMail, false);
                Session["CariMail"] = auth.CariMail.ToString();
                return RedirectToAction("Index", "MusteriPanel");
            }


            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)

        {
            var auth = c.Admins.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);

            if (auth != null)
            {
                FormsAuthentication.SetAuthCookie(a.KullaniciAd, false);
                Session["KullaniciAd"] = auth.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }


            return RedirectToAction("Index", "Login");
        }
    }
}