using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class PermisoController : Controller
    {
        private PermisoLDN permisoldn;
        private EmpleadoLDN empleldn;

        public PermisoController()
        {
            permisoldn = new PermisoLDN();
            empleldn = new EmpleadoLDN();
        }


        // GET: Admin/Permiso
        public ActionResult Index()
        {
            var x = permisoldn.GetAll();
            return View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = empleldn.GetAll().Where(y => y.Estatus=="A").Select(x => new SelectListItem()
            {
                Text = x.Nombre + " " + x.Apellido + " (" + x.CodigoEmp + ") ",
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public ActionResult Create(Permiso permi)
        {
            if (ModelState.IsValid)
            {
                permisoldn.Insert(permi);
                return RedirectToAction("Index", "Permiso", new {area = "Admin"});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.EmpleadoId = empleldn.GetAll().Where(y => y.Estatus == "A").Select(w => new SelectListItem()
            {
                Text = w.Nombre + " " + w.Apellido + " (" + w.CodigoEmp + ") ",
                Value = w.Id.ToString()
            });

            var x = permisoldn.GetById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(Permiso permi)
        {
            if (ModelState.IsValid)
            {
                permisoldn.Update(permi);
                return RedirectToAction("Index", "Permiso", new {area = "Admin"});
            }

            return View();
        }

        public ActionResult Delete(int id)
        {

            try
            {
                permisoldn.Delete(id);
                return RedirectToAction("Index", "Permiso", new {area = "Admin"});
            }
            catch
            {
                TempData["Error"] = "Error al eliminar permiso,intentelo de nuevo";
                return RedirectToAction("Index", "Permiso", new { area = "Admin" });
            }

        }


    }
}