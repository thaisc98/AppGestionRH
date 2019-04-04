using System.Web.Mvc;

namespace AppFinalRH.Areas.Lobby.Controllers
{
    [AllowAnonymous]
    public class PrincipalController : Controller
    {
        // GET: Lobby/Principal
        public ActionResult Index()
        {
            return View();
        }
    }
}