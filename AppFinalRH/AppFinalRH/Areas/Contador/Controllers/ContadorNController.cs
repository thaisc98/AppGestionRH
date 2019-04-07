using System.Collections.Generic;
using System.Linq;
using LDN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Contador.Controllers
{
    [Authorize(Roles = "C")]
    public class ContadorNController : Controller
    {
        public NominaLDN nominldnn;

        public ContadorNController() => nominldnn = new NominaLDN();
       
        // GET: Contador/ContadorN
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ?  "P" : Status);

            if (Status == null)
            {
                var y = nominldnn.GetPending();
                return View(y);
            }
            else
            {
                return View(nominldnn.GetAll().Where(x => x.Estatus == Status));
            }
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var y = nominldnn.GetById(id);
                y.Estatus = "A";
                nominldnn.Update(y);
                return RedirectToAction("Index", "ContadorN");
            }
            catch
            {
                TempData["Msg"] = "Error al aprobar nomina. ";
                return RedirectToAction("Index", "ContadorN");

            }
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var y = nominldnn.GetById(id);
                y.Estatus = "R";
                nominldnn.Update(y);
                return RedirectToAction("Index", "ContadorN");
            }
            catch
            {
                TempData["Msg"] = "Error al reprobar nomina. ";
                return RedirectToAction("Index", "ContadorN");

            }
        }
        

        public void ApproveOrRejectAll(List<int> Ids,string Status)
        {
            try
            {
                TempData["Msg"] = "Operacion exitosa [ Aprobar/Reprobar] .";
                nominldnn.ApproveOrRejectAll(Ids,Status);
            }
            catch
            {
                TempData["Msg"] = "Error al Aprobar/Reprobar.";
            }
     
        }
    }
}