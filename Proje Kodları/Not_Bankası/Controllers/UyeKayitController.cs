using Not_Bankası.Models.VeriTabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Not_Bankası.Controllers
{
    [AllowAnonymous]
    public class UyeKayitController : Controller
    {
        NotBankasiEntities NotBankasiDB = new NotBankasiEntities();
        // GET: UyeKayit
        public ActionResult UyeKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeKayit(string adi, string email,string sifre,string sifreOnayla)
        {
            var varmi = NotBankasiDB.UyeBilgileris.FirstOrDefault(x => x.EMail == email);
            if (varmi == null)
            {
                UyeBilgileri uye = new UyeBilgileri();

                if (sifre == sifreOnayla)
                {
                    uye.EMail = email;
                    uye.KullanıcıAdı = adi;
                    uye.Sifre = sifre;
                    NotBankasiDB.UyeBilgileris.Add(uye);
                    NotBankasiDB.SaveChanges();
                    return RedirectToAction("UyeGirsi", "UyeGiris");
                }
                else
                    ViewBag.mesaj += "Şifreler eşleşmiyor";
            }
            else
            {
                ViewBag.mesaj += "Sistemde böyle bir kullanıcı var";
            }
            return View();
        }

    }
}