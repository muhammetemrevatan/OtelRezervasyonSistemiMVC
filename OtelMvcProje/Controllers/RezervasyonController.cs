using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        DbOtelEntities1 db = new DbOtelEntities1();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(TblRezervasyon p)
        {
            var misafirMail = (string)Session["Mail"];
            var misafirid = db.TblYeniKayits.Where(x => x.Mail == misafirMail).Select(x => x.ID).FirstOrDefault();
            p.Durum = 14;
            p.Misafir = misafirid;
            db.TblRezervasyons.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}