﻿using System;
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
        public ActionResult Index(TblOnRezervasyon p)
        {
            var misafirMail = (string)Session["Mail"];
            //var misafirid = db.TblYeniKayits.Where(x => x.Mail == misafirMail).Select(x => x.ID).FirstOrDefault();
            //p.Misafir = misafirid;
            p.Mail = misafirMail;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblOnRezervasyons.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}