using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPaneli.Models.Entity;
using MvcCvPaneli.Repositories;

namespace MvcCvPaneli.Controllers
{
    public class YetenekController : Controller
    {
        
        GenericRepository<TBLYETENEKLERIM> repo = new GenericRepository<TBLYETENEKLERIM>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEKLERIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TBLYETENEKLERIM t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}