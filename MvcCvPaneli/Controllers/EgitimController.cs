using MvcCvPaneli.Models.Entity;
using MvcCvPaneli.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvPaneli.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBLEGITIM> repo = new GenericRepository<TBLEGITIM>();

       
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLEGITIM p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDüzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDüzenle(TBLEGITIM t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDüzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.Tarih = t.Tarih;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}