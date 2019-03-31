using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Lobby.Controllers
{
    public class PrincipalController : Controller
    {
       

        // GET: Lobby/Principal
        public ActionResult Index()
        {
            return View();
        }
    }
}