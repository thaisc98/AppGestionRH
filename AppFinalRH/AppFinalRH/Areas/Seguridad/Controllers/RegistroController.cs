using LDN;
using ODN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Seguridad.Controllers
{
    [AllowAnonymous]
    public class RegistroController : Controller
    {
        private UsuarioLDN usuarioldn;

        public RegistroController() => usuarioldn = new UsuarioLDN();

        // GET: Seguridad/Registro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "A";
                    usuarioldn.Insert(user);
                    return RedirectToAction("Index", "Principal", new{area="Lobby"});
                }

            }
            catch
            {
                TempData["Error"] = "Error al registrarse, intentelo mas tarde";
                return RedirectToAction("Index", "Registro", new{area="Seguridad"});
            }
      
            return View();
        }


    }
}