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
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
    }
}
