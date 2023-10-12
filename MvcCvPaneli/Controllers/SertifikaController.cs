using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPaneli.Models.Entity;
using MvcCvPaneli.Repositories;

namespace MvcCvPaneli.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLSERTIFIKALARIM> repo = new GenericRepository<TBLSERTIFIKALARIM>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir( int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBLSERTIFIKALARIM t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TBLSERTIFIKALARIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID ==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}