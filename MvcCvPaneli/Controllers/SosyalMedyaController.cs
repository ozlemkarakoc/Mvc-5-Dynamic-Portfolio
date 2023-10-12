using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPaneli.Models.Entity;
using MvcCvPaneli.Repositories;

namespace MvcCvPaneli.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TBLSOSYALMEDYA> repo = new GenericRepository<TBLSOSYALMEDYA>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLSOSYALMEDYA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TBLSOSYALMEDYA p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.AD = p.AD;
            hesap.DURUM = true;
            hesap.LINK = p.LINK;
            hesap.ICON = p.ICON;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.DURUM = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}