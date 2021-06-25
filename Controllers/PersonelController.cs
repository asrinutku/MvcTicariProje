using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {

            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.d = departmanlar;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
           
            if (Request.Files.Count > 0)
            {
                string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaad + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaad + uzanti;

            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelGetir(int id)
        {

            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.Departmanid.ToString() }).ToList();
            ViewBag.d = departmanlar;

            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);

        }

        public ActionResult PersonelGuncelle(Personel p)
        {

            if (Request.Files.Count > 0)
            {
                string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaad + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaad + uzanti;

            }
            var prsn = c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}