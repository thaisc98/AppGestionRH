using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class NominaIController : Controller
    {
        private NominaLDN nominaLdn;

        public NominaIController() => nominaLdn = new NominaLDN();

        
        [HttpGet]
        public ActionResult Index(string Estado, string buscarPor, string buscar)
        {
            if (buscarPor == "Mes")
            {
                return View(nominaLdn.GetAll().Where(x => x.Mes.Descripcion.StartsWith(buscar) || buscar == null));
            }
            else if (buscarPor == "Anio")
            {
                return View(nominaLdn.GetAll().Where(x => x.Anio.ToString().StartsWith(buscar) || buscar == null));
            }

            ViewBag.Estado = (Estado == null ? "A" : Estado);

            if (Estado == "A")
            {
                return View(nominaLdn.GetApproved());
            }
            else if (Estado == "R")
            {
                return View(nominaLdn.GetDenied());
            }
            else if(Estado == "P")
            {
                return View(nominaLdn.GetPending());

            }

            return View(nominaLdn.GetApproved());

        }

    }
}