using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvPaneli.Models.Entity;
using MvcCvPaneli.Repositories;

namespace MvcCvPaneli.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBLILETISIM> repo = new GenericRepository<TBLILETISIM>();

        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}