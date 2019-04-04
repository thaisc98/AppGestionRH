using System;
using System.Linq;
using LDN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class LicenciaIController : Controller
    {
        private LicenciaLDN l;

        public LicenciaIController() => l = new LicenciaLDN();

        // GET: Informe/LicenciaI
        public ActionResult Index(string Page)
        {
            var x = l.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);
        }
    }
}