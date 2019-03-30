using LDN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    public class DepartamentoIController : Controller
    {
        private DepartamentoLDN dldn;
        public DepartamentoIController()
        {
            dldn = new DepartamentoLDN();
        }
        // GET: Informe/DepartamentoI
        public ActionResult Index()
        {
            var x = dldn.GetAll();
            return View(x);
        }
    }
}