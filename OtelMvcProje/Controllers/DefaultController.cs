using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbOtelEntities1 db = new DbOtelEntities1();
        
        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimdas.ToList();
            return View(veriler);
        }

        public PartialViewResult Ekibimiz()
        {
            var ekiplistesi = db.TblEkibimizs.ToList();
            return PartialView(ekiplistesi);
        }

        public PartialViewResult istatistik()
        {

            return PartialView();
        }

        [HttpGet]
        public PartialViewResult PartialFooter()
        {
            var doluoda = db.TblOdas.Where(x => x.Durum != 1).Count();
            ViewBag.d = doluoda;
            var bosoda = db.TblOdas.Where(x => x.Durum == 1).Count();
            ViewBag.b = bosoda;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialFooter(TblMailBirakanlar p)
        {
            db.TblMailBirakanlars.Add(p);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
        
    }
}
