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
        public ActionResult Index(string Estatus, string buscarPor, string buscar)
        {
            if (buscarPor == "Departamento")
            {
                return View(empldn.GetAll().Where(x => x.Departamento.CodigoDep.StartsWith(buscar) || buscar == null));
            }
            else if (buscarPor == "Nombre")
            {
                return View(empldn.GetAll().Where(x => x.Nombre.StartsWith(buscar) || buscar == null));
            }


            ViewBag.Estatus = (Estatus == null ? "A" : Estatus);
            if (Estatus == "A")
            {
                return View(empldn.GetActives());
            }
            else if (Estatus == "I")
            {
                return View(empldn.GetInactives());
            }


            return View(empldn.GetActives());

        }
    }
}