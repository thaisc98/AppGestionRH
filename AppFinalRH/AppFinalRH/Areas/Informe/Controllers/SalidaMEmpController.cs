using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Informe.Controllers
{
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