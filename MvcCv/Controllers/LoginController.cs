using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var girisBilgisi = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi ==
                p.KullaniciAdi && x.Sifre == p.Sifre);
            if (girisBilgisi != null)
            {
                FormsAuthentication.SetAuthCookie(girisBilgisi.KullaniciAdi,false);
                Session["KullaniciAdi"] = girisBilgisi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                return RedirectToAction("Index");

            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}