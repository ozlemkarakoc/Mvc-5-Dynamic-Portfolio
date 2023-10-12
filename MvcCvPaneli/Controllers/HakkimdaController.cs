using MvcCvPaneli.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPaneli.Models.Entity;

namespace MvcCvPaneli.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvPaneliEntities db = new DbCvPaneliEntities();
        GenericRepository<TBLHAKKIMDA> repo = new GenericRepository<TBLHAKKIMDA>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBLHAKKIMDA p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}