using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class PermisoIController : Controller
    {
        private PermisoLDN permisoLdn;

        public PermisoIController()
        {
            permisoLdn = new PermisoLDN();
        }
        // GET: Informe/PermisoI
        public ActionResult Index(string a)
        {
            return View(permisoLdn.GetAll());
        }
    }
}