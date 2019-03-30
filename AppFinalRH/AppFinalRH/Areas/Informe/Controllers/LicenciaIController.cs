using LDN;
using System.Web.Mvc;

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