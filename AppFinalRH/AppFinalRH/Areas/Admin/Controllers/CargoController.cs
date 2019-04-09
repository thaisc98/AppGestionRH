using LDN;
using ODN;
using System;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class CargoController : Controller
    {
        private CargoLDN cargoldn;
        private EmpleadoLDN empldn;

        public CargoController()
        {
            cargoldn = new CargoLDN();
            empldn = new EmpleadoLDN();
        }


        // GET: Cargo
       
        public  ActionResult Index(string Page)
        {
            var x =  cargoldn.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return  View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargoldn.Insert(cargo);
                return RedirectToAction("Index", "Cargo",new{area ="Admin"});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var x =  cargoldn.GetById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargoldn.Update(cargo);
                return RedirectToAction("Index", "Cargo",new{area ="Admin"});
            }

            return View();
        }

        public ActionResult Delete(int id)
        {

            try
            {
                int count = empldn.GetAll().Where(x => x.CargoId == id).Count();

                if (count != 0)
                {
                    TempData["Msg"] = "Error al eliminar cargo, intentelo de nuevo ";

                }

                cargoldn.Delete(id);
                return RedirectToAction("Index", "Cargo");
            }
            catch
            {
                TempData["Msg"] = "Error al eliminar cargo, intentelo de nuevo ";
                return RedirectToAction("Index", "Cargo", new {area = "Admin"});
            }
            
        }



    }
}