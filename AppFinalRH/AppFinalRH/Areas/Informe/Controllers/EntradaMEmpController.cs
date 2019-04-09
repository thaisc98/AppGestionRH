using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class EntradaMEmpController : Controller
    {

        public EmpleadoLDN empldn;

        public EntradaMEmpController() => empldn = new EmpleadoLDN();
        
        // GET: Informe/EntradaMEmp
        public ActionResult Index(string buscarPor,string buscar)
        {
            if (buscarPor == "Mes")
            {
                return View(empldn.GetAll().Where(y => y.FechaIngreso.Month.ToString().StartsWith(buscar) || buscar == null));
            }
            else if (buscarPor == "Anio")
            {
                return View(empldn.GetAll().Where(y => y.FechaIngreso.Year.ToString().StartsWith(buscar) || buscar == null));
            }
            var x = empldn.GetAll();
            return View(x);
        }

    }
}