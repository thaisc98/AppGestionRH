using LDN;
using System.Web.Mvc;

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