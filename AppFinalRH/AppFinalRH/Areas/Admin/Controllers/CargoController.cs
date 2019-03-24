using System;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class CargoController : Controller
    {
        private CargoLDN cargoldn;

        public CargoController()
        {
            cargoldn = new CargoLDN();
        }


        // GET: Cargo
        public ActionResult Index()
        {
            var x = cargoldn.GetAll();
            return View(x);
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
            var x = cargoldn.GetById(id);
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
                cargoldn.Delete(id);
               return RedirectToAction("Index", "Cargo");
            }
            catch
            {
                TempData["Error"] = "Error al eliminar cargo,intentelo de nuevo";
                return RedirectToAction("Index", "Cargo", new {area = "Admin"});
            }
            
        }



    }
}