﻿using System;
using LDN;
using ODN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class LicenciaController : Controller
    {
        private LicenciaLDN liceldn;
        private EmpleadoLDN empleldn;


        public LicenciaController()
        {
            liceldn = new LicenciaLDN();
            empleldn = new EmpleadoLDN();
        }

        // GET: Admin/Licencia
        public ActionResult Index(string Page)
        {
            var x = liceldn.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = empleldn.GetAll().Where(y => y.Estatus == "A").Select(x => new SelectListItem()
            {
                Text = x.Nombre + " " + x.Apellido + " (" + x.CodigoEmp + ") ",
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public ActionResult Create(Licencia lice)
        {
            if (ModelState.IsValid)
            {
                liceldn.Insert(lice);
                return RedirectToAction("Index", "licencia", new { area = "Admin" });
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

            var x = liceldn.GetById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(Licencia lice)
        {
            if (ModelState.IsValid)
            {
                liceldn.Update(lice);
                return RedirectToAction("Index", "licencia", new { area = "Admin" });
            }

            return View();
        }

        public ActionResult Delete(int id)
        {

            try
            {
                liceldn.Delete(id);
                return RedirectToAction("Index", "licencia", new { area = "Admin" });
            }
            catch
            {
                TempData["Msg"] = "Error al eliminar licencia,intentelo de nuevo";
                return RedirectToAction("Index", "licencia", new { area = "Admin" });
            }

        }

    }
}