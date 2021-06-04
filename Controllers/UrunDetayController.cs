using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            UrunDetayBl bl = new UrunDetayBl();
            //var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            bl.Deger1 = c.Uruns.Where(x => x.Urunid == 1).ToList();
            bl.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(bl);
        }
    }
}