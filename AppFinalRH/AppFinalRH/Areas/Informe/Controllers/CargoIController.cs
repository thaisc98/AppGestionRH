using System;
using System.Linq;
using System.Threading.Tasks;
using LDN;
using System.Web.Mvc;
using System.Web.UI;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class CargoIController : Controller
    {
        private CargoLDN c;

        public CargoIController() => c = new CargoLDN();

        // GET: Informe/CargoI
        public ActionResult Index(string Page)
        {
            var x = c.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);
        }
    }
}