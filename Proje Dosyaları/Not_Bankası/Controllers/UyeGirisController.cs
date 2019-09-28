using Not_Bankası.Models.VeriTabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Not_Bankası.Controllers
{
    public class UyeGirisController : Controller
    {
        NotBankasiEntities NotBankasiDB = new NotBankasiEntities();
        // GET: UyeGiris
        [AllowAnonymous]
        public ActionResult UyeGiris()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return RedirectToAction("UyeProfilDuzenle", "UyeProfilDuzenle");
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult UyeGiris(UyeBilgileri GelenUye, string benihatirla)
        {
            if (ModelState.IsValid)
            {
                var GirenUye = NotBankasiDB.UyeBilgileris.FirstOrDefault(x => x.EMail == GelenUye.EMail && x.Sifre == GelenUye.Sifre);
                if (GirenUye!=null)
                {
                    //if (benihatirla == "true")
                    //FormsAuthentication.SetAuthCookie(GelenUye.EMail, true);
                    
                    if (benihatirla=="true")
                    {

                        var cookie = FormsAuthentication.GetAuthCookie(GelenUye.EMail, true);
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(GelenUye.EMail, false);
                    }

                    return RedirectToAction("UyeProfilDuzenle", "UyeProfilDuzenle",GelenUye);
                }
                else
                {
                    ModelState.AddModelError("", "Mail veya şifre hatalı!");

                }
            }

            return View(GelenUye);
        }

        public ActionResult UyeCikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("UyeGiris", "UyeGiris");
        }
    }
}