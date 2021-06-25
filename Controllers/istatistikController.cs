using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var d1 = c.Carilers.Count().ToString();
            ViewBag.d1 = d1;

            var d2 = c.Uruns.Count().ToString();
            ViewBag.d2 = d2;

            var d3 = c.Personels.Count().ToString();
            ViewBag.d3 = d3;

            var d4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = d4;

            var d5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = d5;

            var d6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = d6;

            var d7 = c.Uruns.Count( x => x.Stok <= 20).ToString();
            ViewBag.d7 = d7;

            var d8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).Distinct().FirstOrDefault();
            ViewBag.d8 = d8;

            var d9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).Distinct().FirstOrDefault();
            ViewBag.d9 = d9;

            var d10 = c.Uruns.Count(x => x.UrunAd =="buzdolabı").ToString();
            ViewBag.d10 = d10;

            var d11 = c.Uruns.Count(x => x.UrunAd == "laptop").ToString();
            ViewBag.d11 = d11;

            var d12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = d12;

            var d13 = c.Uruns.Where(u => u.Urunid == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = d13;

            var d14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = d14;

            DateTime bugun = DateTime.Today;
            var d15 = c.SatisHarekets.Count().ToString();
            ViewBag.d15 = d15;

            var d16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = d16;


            return View();

        }
        public ActionResult Tablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()

                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partialv()
        {
            var sorgu = from x in c.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()

                        };
            return PartialView(sorgu.ToList());

            
        }

        public PartialViewResult Partialv2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);


        }

        public PartialViewResult Partialv3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);


        }

        public PartialViewResult Partialv4()
        {

            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new UrunMarkaGrup
                        {
                            Marka = g.Key,
                            sayi = g.Count()

                        };
            return PartialView(sorgu.ToList());


        }
    }
}