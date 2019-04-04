using LDN;
using ODN;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class SalidaEmpleadoController : Controller
    {
        private SalidaEmpleadoLDN saliempleldn;
        private EmpleadoLDN empleldn;

        public SalidaEmpleadoController()
        {
            saliempleldn = new SalidaEmpleadoLDN();
            empleldn = new EmpleadoLDN();
        }


        // GET: Admin/saliemple
        public ActionResult Index(string Page)
        {
            var x = saliempleldn.GetAll();

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



            ViewBag.Id_Empleado = empleldn.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Nombre + " " + x.Apellido,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public ActionResult Create(SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                var x = empleldn.GetActives().Where(y => y.Id == salidaEmpleado.EmpleadoId);
                var instanciavalor = x.First();
                instanciavalor.Estatus = "I";
                empleldn.Update(instanciavalor);
                saliempleldn.Insert(salidaEmpleado);
                return RedirectToAction("Index", "SalidaEmpleado", new { area = "Admin" });
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

            var x = saliempleldn.GetById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                saliempleldn.Update(salidaEmpleado);
                return RedirectToAction("Index", "SalidaEmpleado", new { area = "Admin" });
            }

            return View();
        }
    }
}