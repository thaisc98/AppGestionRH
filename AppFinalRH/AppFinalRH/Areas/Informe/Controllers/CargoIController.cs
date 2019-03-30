using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class CargoIController : Controller
    {
        private CargoLDN c;
        public CargoIController()
        {
            c = new CargoLDN();
        }
        // GET: Informe/CargoI
        public ActionResult Index()
        {
            var x = c.GetAll();
            return View(x);
        }
    }
}