using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;


namespace MvcTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string ktn)
        {

            var k = from x in c.KargoDetays select x;
            if(!string.IsNullOrEmpty(ktn))
            {
                k = k.Where(y => y.TakipKodu.Contains(ktn));
            }
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult KargoEkle()
        {

            var rnd = new Random();
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;



            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;

            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);

            int s1, s2, s3;

            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 100);
            s3 = rnd.Next(10, 100);

            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];

            ViewBag.tk = kod;






            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(KargoDetay k)
        {

            k.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.KargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}