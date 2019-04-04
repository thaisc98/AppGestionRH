using LDN;
using ODN;
using System.Web.Mvc;
using System.Web.Security;

namespace AppFinalRH.Areas.Seguridad.Controllers
{
    [AllowAnonymous]
    public class ISesionController : Controller
    {
        private UsuarioLDN userldn;

        public ISesionController() => userldn = new UsuarioLDN();

        // GET: Seguridad/ISesion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario user)
        {
            try
            {
                if (Membership.ValidateUser(user.Email, user.Contra))
                {
                    FormsAuthentication.SetAuthCookie(user.Email,false);
                    return RedirectToAction("Index", "Principal", new {area= "Lobby"});
                }
            }
            catch
            {
                TempData["MensajeE"] = "Ha ocurrido un error al iniciar sesión";
                return RedirectToAction("Index", "ISesion");
            }
            return View();
        }


      
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Principal", new { area = "Lobby" });
        }


    }
}