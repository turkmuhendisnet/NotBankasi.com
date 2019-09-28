using Not_Bankası.Controllers.GirisKontrolleri;
using Not_Bankası.Models.VeriTabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Not_Bankası.Controllers
{
    [_SessionController]
    public class UyeProfilDuzenleController : Controller
    {
        // GET: UyeProfilDuzele
        
       
        NotBankasiEntities NotBankasiDB = new NotBankasiEntities();
        // GET: UyeProfilDuzele
        public ActionResult UyeProfilDuzenle(UyeBilgileri kullanici)
        {
            List<Universite> unis = NotBankasiDB.Universites.ToList();
            ViewBag.Unis = unis;
            var gelenKullanici = NotBankasiDB.UyeBilgileris.Where(x => x.Uye_Id == kullanici.Uye_Id).FirstOrDefault();
            return View(gelenKullanici);


        }

        [HttpPost]
        public JsonResult BolumSecme(int id)
        {
            var UniversiteBolumler = (from c in NotBankasiDB.Universite_Bolum
                                      where c.Universite_Id == id
                                      select c.BolumAdı).ToList();

            return Json(UniversiteBolumler);
        }
    }
}