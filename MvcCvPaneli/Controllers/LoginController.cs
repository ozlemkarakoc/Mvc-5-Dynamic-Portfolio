using MvcCvPaneli.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCvPaneli.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public object FormAuthentication { get; private set; }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMIN p)
        {
            DbCvPaneliEntities db = new DbCvPaneliEntities();
            var bilgi = db.TBLADMIN.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Egitim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}