using System;
using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class EmpleadoIController : Controller
    {
        private EmpleadoLDN empldn;

        public EmpleadoIController() => empldn = new EmpleadoLDN();

        // GET: Informe/EmpleadoI
        public ActionResult Index(string Estatus, string buscarPor, string buscar, string Page)
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

            var abc = empldn.GetActives();

            ViewBag.TotalPages = Math.Ceiling(abc.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            abc = abc.Skip((page - 1) * 10).Take(10);
            return View(abc);
        }
    }
}