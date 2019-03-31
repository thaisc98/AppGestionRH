using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class SalidaEmpleadoIController : Controller
    {
        private SalidaEmpleadoLDN salidaEmpleadoLdn;

        public SalidaEmpleadoIController()
        {
            salidaEmpleadoLdn = new SalidaEmpleadoLDN();
        }

        // GET: Informe/SalidaEmpleadoI
        public ActionResult Index()
        {
            return View(salidaEmpleadoLdn.GetAll());
        }
    }
}