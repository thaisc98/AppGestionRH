using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class LicenciaIController : Controller
    {
        private LicenciaLDN l;
        public LicenciaIController()
        {
            l = new LicenciaLDN();
        }
        // GET: Informe/LicenciaI
        public ActionResult Index()
        {
            var x = l.GetAll();
            return View(x);
        }
    }
}