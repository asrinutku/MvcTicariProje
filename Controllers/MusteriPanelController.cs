using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class MusteriPanelController : Controller
    {
        Context c = new Context();
        // GET: MusteriPanel
        [Authorize]
        

        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        public ActionResult Siparisler()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }


        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var a = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var b = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            
            ViewBag.d1 = a;
            ViewBag.d2 = b;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var a = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var b = c.Mesajlars.Count(x => x.Alici == mail).ToString();

            ViewBag.d1 = b;
            ViewBag.d2 = a;
            return View(mesajlar);
        }

        public ActionResult Mesaj(int id)
        {
            var mesaj = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var a = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var b = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d1 = a;
            ViewBag.d2 = b;
            return View(mesaj);
        }




        [HttpGet]
        public ActionResult YeniMesaj()
        {   
            var mail = (string)Session["CariMail"];
            var a = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var b = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d1 = a;
            ViewBag.d2 = b;
            return View();

        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Gonderici = mail;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            c.SaveChanges();
            
            return View();

        }
    }
}