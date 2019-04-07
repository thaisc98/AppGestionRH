using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class EntradaMEmpController : Controller
    {

        public EmpleadoLDN empldn;


        public EntradaMEmpController() => empldn = new EmpleadoLDN();
        



        // GET: Informe/EntradaMEmp
        public ActionResult Index(string buscarPor,string buscar)
        {
            if (buscarPor == "Mes")
            {
                return View(empldn.GetAll().Where(y => y.FechaIngreso.Month.ToString() == buscar || buscar == null));
            }
            else if (buscarPor == "Anio")
            {
                return View(empldn.GetAll().Where(y => y.FechaIngreso.Year.ToString() == buscar|| buscar == null));
            }

            var x = empldn.GetAll();
            return View(x);
        }






    }
}