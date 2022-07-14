using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class MisafirController : Controller
    {
        // GET: Misafir

        DbOtelEntities1 db = new DbOtelEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rezervasyonlarim()
        {
            var misafirMail = (string)Session["Mail"];
            ViewBag.a = misafirMail;
            var degerler = db.TblRezervasyons.Where(x => x.Misafir == 5).ToList();
            return View(degerler);
        }
    }
}