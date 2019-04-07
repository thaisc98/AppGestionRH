using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class SalidaMEmpController : Controller
    {

        public SalidaEmpleadoLDN salidaemp;

        public SalidaMEmpController() => salidaemp = new SalidaEmpleadoLDN();
        
        // GET: Informe/SalidaMEmp
        public ActionResult Index(string buscarPor, string buscar)
        {
            if (buscarPor == "Mes")
            {
                return View(salidaemp.GetAll().Where(y => y.FechaSalida.Month.ToString() == buscar || buscar == null));
            }
            else if (buscarPor == "Anio")
            {
                return View(salidaemp.GetAll().Where(y => y.FechaSalida.Year.ToString() == buscar || buscar == null));
            }

            var x = salidaemp.GetAll();
            return View(x);
        }
    }
}