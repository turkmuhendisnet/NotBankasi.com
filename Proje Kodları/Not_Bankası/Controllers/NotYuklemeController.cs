using Not_Bankası.Controllers.GirisKontrolleri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Not_Bankası.Controllers
{
    public class NotYuklemeController : Controller
    {
        // GET: NotYukleme
        [_SessionController]
        public ActionResult NotYukleme()
        {
            return View();
        }
    }
}