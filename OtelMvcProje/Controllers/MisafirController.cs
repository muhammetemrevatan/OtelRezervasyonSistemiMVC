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
            var degerler = db.TblOnRezervasyons.Where(x => x.Mail == misafirMail).ToList();
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

        public ActionResult GelenMesajlar()
        {
            var misafirMail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Alici == misafirMail).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var misafirMail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Gonderen == misafirMail).ToList();
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var mesaj = db.TblMesaj2.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj2 p)
        {
            var misafirMail = (string)Session["Mail"];
            p.Gonderen = misafirMail;
            p.Alici = "Admin";
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesaj2.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
    }
}