﻿using System;
using System.Linq;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class EmpleadoController : Controller
    {
        private EmpleadoLDN empleadEmpleadoLDN;
        private DepartamentoLDN departamentoLDN;
        private CargoLDN cargoLDN;

        public EmpleadoController()
        {
            empleadEmpleadoLDN = new EmpleadoLDN();
            departamentoLDN = new DepartamentoLDN();
            cargoLDN = new CargoLDN();
        }


        // GET: Admin/EmpleadoAdmin
        [HttpGet]
        public ActionResult Index()
        {
            return View(empleadEmpleadoLDN.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(departamentoLDN.GetAll().ToList(), "Id", "NombreDep");
            ViewBag.CargoId = new SelectList(cargoLDN.GetAll().ToList(), "Id", "NombreCargo");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Estatus = "A";
                empleadEmpleadoLDN.Insert(empleado);

                return RedirectToAction("Index", "Empleado", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.DepartamentoId = new SelectList(departamentoLDN.GetAll().ToList(), "Id", "NombreDep");
            ViewBag.CargoId = new SelectList(cargoLDN.GetAll().ToList(), "Id", "NombreCargo");

            return View(empleadEmpleadoLDN.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleadEmpleadoLDN.Update(empleado);
                return RedirectToAction("Index", "Empleado", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                empleadEmpleadoLDN.Delete(id);
                return RedirectToAction("Index", "Empleado", new { area = "Admin" });
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error: al eliminar el empleado. Inténtelo de nuevo";
                return RedirectToAction("Index", "Empleado");
            }
        }
    }

}