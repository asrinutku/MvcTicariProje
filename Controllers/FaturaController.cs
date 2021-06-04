using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {

            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaGetir(int id)
        {
            var ft = c.Faturalars.Find(id);
            return View("FaturaGetir", ft);


        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = c.Faturalars.Find(f.Faturaid);
            fat.FaturaSeri = f.FaturaSeri;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.Tarih = f.Tarih;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
         
            c.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id ).ToList();
          
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KalemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KalemEkle(FaturaKalem fk)
        {

            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}