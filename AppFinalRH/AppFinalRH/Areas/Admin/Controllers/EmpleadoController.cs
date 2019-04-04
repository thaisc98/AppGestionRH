using System;
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
        public ActionResult Index(/*string SortOrder, string SortBy, */string Page)
        {
        /*    ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var empleados = empleadEmpleadoLDN.GetActives();

            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;


            switch (SortOrder)
            {
                case "CodigoEmp":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.CodigoEmp).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.CodigoEmp).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Nombre":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Nombre).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Nombre).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Apellido":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Apellido).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Apellido).ToList();
                            break;
                        default:
                            break;
                    }

                    break;
                case "Edad":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Edad).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Edad).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Telefono":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Telefono).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Telefono).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Departamento":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Departamento.NombreDep).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Departamento.NombreDep).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Cargo":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Cargo.NombreCargo).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Cargo.NombreCargo).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "FechaIngreso":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.FechaIngreso).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.FechaIngreso).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Salario":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Salario).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Salario).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Estatus":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Estatus).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Estatus).ToList();
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    empleados = empleados.OrderBy(x => x.Nombre).ToList();
                    break;
            }*/

        var empleados = empleadEmpleadoLDN.GetActives();

            ViewBag.TotalPages = Math.Ceiling(empleados.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            empleados = empleados.Skip((page - 1) * 10).Take(10);


            return View(empleados);
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
