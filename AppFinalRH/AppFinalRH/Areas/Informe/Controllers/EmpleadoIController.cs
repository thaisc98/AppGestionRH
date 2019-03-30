using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;

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
        public ActionResult Index(string buscarPo, string buscar)
        {
            if (buscarPo == "Departamento")
            {
                return View(empldn.GetActives().Where(x => x.Departamento.CodigoDep.StartsWith(buscar) || buscar == null));
            }
            else if (buscarPo == "Nombre")
            {
                return View(empldn.GetActives().Where(x => x.Nombre.StartsWith(buscar) || buscar == null));
            }
            
            return View(empldn.GetActives());
        }
    }
}