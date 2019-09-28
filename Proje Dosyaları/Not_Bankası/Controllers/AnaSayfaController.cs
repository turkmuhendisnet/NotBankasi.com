using Not_Bankası.Models.VeriTabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Not_Bankası.Controllers
{
    [AllowAnonymous]
    public class AnaSayfaController : Controller
    {
        NotBankasiEntities NotBankasiDB = new NotBankasiEntities();

        public ActionResult AnaSayfa()
        {
            List<Universite> UniversitelerListesi = NotBankasiDB.Universites.ToList();


            return View(UniversitelerListesi);
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