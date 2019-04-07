using System;
using System.Linq;
using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class PermisoIController : Controller
    {
        private PermisoLDN permisoLdn;

        public PermisoIController() => permisoLdn = new PermisoLDN();


        // GET: Informe/PermisoI
        public ActionResult Index(string Page)
        {
            var x = permisoLdn.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);
        }
    }
}