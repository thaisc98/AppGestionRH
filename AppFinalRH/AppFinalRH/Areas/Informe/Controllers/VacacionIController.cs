using System.Web.Mvc;
using LDN;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class VacacionIController : Controller
    {
        private VacacionLDN vacacionLdn;

        public VacacionIController()
        {
            vacacionLdn = new VacacionLDN();
        }

        // GET: Informe/VacacionI
        public ActionResult Index()
        {
            return View(vacacionLdn.GetAll());
        }
    }
}