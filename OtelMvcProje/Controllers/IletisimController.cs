using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim

        DbOtelEntities1 db = new DbOtelEntities1();
        public ActionResult Index()
        {
            var bilgiler = db.TblIletisims.ToList();
            return View(bilgiler);
        }

        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesajs.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}