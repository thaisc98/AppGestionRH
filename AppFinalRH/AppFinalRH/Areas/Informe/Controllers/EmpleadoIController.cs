using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class EmpleadoIController : Controller
    {
        private EmpleadoLDN empldn;

        public EmpleadoIController()
        {
            empldn = new EmpleadoLDN();
        }
        // GET: Informe/EmpleadoI
        public ActionResult Index(string estado, string buscarPor, string buscar)
        {

            if (buscarPor == "Departamento")
            {
                return View(empldn.GetActives().Where(x => x.Departamento.CodigoDep.StartsWith(buscar) || buscar == null));
            }
            else if (buscarPor == "Nombre")
            {
                return View(empldn.GetActives().Where(x => x.Nombre.StartsWith(buscar) || buscar == null));
            }

            ViewBag.Status = (estado == null ? "A" : estado);
            if (estado == null)
            {
                return View(empldn.GetActives());
            }
            else
            {
                return View(empldn.GetInactives());
            }

        }
    }
}