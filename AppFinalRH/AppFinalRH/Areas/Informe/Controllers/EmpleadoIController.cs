using System;
using LDN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class EmpleadoIController : Controller
    {
        private EmpleadoLDN empldn;

        public EmpleadoIController() => empldn = new EmpleadoLDN();

        // GET: Informe/EmpleadoI
        public ActionResult Index(string Estatus, string buscarPor, string buscar, string SortOrder, string SortBy,string Page)
        {
            if (buscarPor == "Departamento")
            {
                return View(empldn.GetAll().Where(x => x.Departamento.CodigoDep.StartsWith(buscar) || buscar == null));
            }
            else if (buscarPor == "Nombre")
            {
                return View(empldn.GetAll().Where(x => x.Nombre.StartsWith(buscar) || buscar == null));
            }


            ViewBag.Estatus = (Estatus == null ? "A" : Estatus);
            if (Estatus == "A")
            {
                return View(empldn.GetActives());
            }
            else if (Estatus == "I")
            {
                return View(empldn.GetInactives());
            }

            var abc = empldn.GetActives();


            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var empleados = empldn.GetAll();

            switch (SortBy)
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
                            empleados = empleados.OrderBy(x => x.FechaIngreso).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.FechaIngreso).ToList();
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
                case "CodigoCargo":
                    switch (SortOrder)
                    {
                        case "Asc":
                            empleados = empleados.OrderBy(x => x.Cargo.CodigoCargo).ToList();
                            break;
                        case "Desc":
                            empleados = empleados.OrderByDescending(x => x.Cargo.CodigoCargo).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    empleados = empleados.OrderBy(x => x.CodigoEmp).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(abc.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            abc = abc.Skip((page - 1) * 10).Take(10);
            return View(abc);
        }
    }
}