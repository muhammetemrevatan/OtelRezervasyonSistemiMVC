using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        // GET: Misafir

        DbOtelEntities1 db = new DbOtelEntities1();
        
        public ActionResult Index()
        {
            var misafirMail = (string)Session["Mail"];
            var misafirBilgi = db.TblYeniKayits.Where(x => x.Mail == misafirMail).FirstOrDefault();
            return View(misafirBilgi);
        }

        public ActionResult Rezervasyonlarim()
        {
            var misafirMail = (string)Session["Mail"];
            //ViewBag.a = misafirMail;
            var misafirid = db.TblYeniKayits.Where(x => x.Mail == misafirMail).Select(y => y.ID).FirstOrDefault();
            var degerler = db.TblRezervasyons.Where(x => x.Misafir == misafirid).ToList();
            return View(degerler);
        }

        public ActionResult MisafirBilgiGuncelle(TblYeniKayit p)
        {
            var misafir = db.TblYeniKayits.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Sifre = p.Sifre;
            misafir.Telefon = p.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
    }
}