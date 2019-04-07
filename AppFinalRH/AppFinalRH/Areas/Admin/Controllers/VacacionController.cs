using System;
using System.Linq;
using System.Web.Mvc;
using LDN;
using ODN;

namespace AppFinalRH.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class VacacionController : Controller
    {
        private VacacionLDN objsBs;
        private EmpleadoLDN objEmpleado;

        public VacacionController()
        {
            objsBs = new VacacionLDN();
            objEmpleado = new EmpleadoLDN();
        }

        // GET: Admin/Vacacion
        public ActionResult Index(string Page)
        {
            var x = objsBs.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(objsBs.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(objEmpleado.GetAll().ToList(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vacacion vacacion)
        {
            if (ModelState.IsValid)
            {
                objsBs.Insert(vacacion);
                return RedirectToAction("Index", "Vacacion", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.EmpleadoId = new SelectList(objEmpleado.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Emp = objsBs.GetAll().Where(x => x.Id == id).
                Select(x => new SelectListItem()
                {
                    Text = x.Empleado.Nombre + " " + x.Empleado.Apellido + " (" + x.Empleado.CodigoEmp + ")",
                    Value = x.Id.ToString()
                });

            string nombre = objEmpleado.GetAll().Where(x => x.Nombre == objsBs.GetById(id).Empleado.Nombre).ToString();
            string apellido = objEmpleado.GetAll().Where(x => x.Nombre == objsBs.GetById(id).Empleado.Nombre).ToString();
            string codigo = objEmpleado.GetAll().Where(x => x.Nombre == objsBs.GetById(id).Empleado.Nombre).ToString();

            string r = nombre + " " + apellido + " (" + codigo + ")";

            ViewBag.Emp = r;

            return View(objsBs.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Vacacion vacacion)
        {
            if (ModelState.IsValid)
            {
                objsBs.Update(vacacion);
                return RedirectToAction("Index", "Vacacion", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                objsBs.Delete(id);
                return RedirectToAction("Index", "Vacacion", new { area = "Admin" });
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error al cancelar vacación. Inténtelo de nuevo.";
                return RedirectToAction("Index", "Vacacion", new { area = "Admin" });
            }
        }
    }
}