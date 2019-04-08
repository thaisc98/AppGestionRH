using System;
using System.Linq;
using LDN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class DepartamentoIController : Controller
    {
        private DepartamentoLDN dldn;

        public DepartamentoIController() => dldn = new DepartamentoLDN();

        // GET: Informe/DepartamentoI
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var departamentos = dldn.GetAll();

            switch (SortBy)
            {
                case "CodigoDep":
                    switch (SortOrder)
                    {
                        case "Asc":
                            departamentos = departamentos.OrderBy(x => x.CodigoDep).ToList();
                            break;
                        case "Desc":
                            departamentos = departamentos.OrderByDescending(x => x.CodigoDep).ToList();
                            break;
                    }
                    break;
                case "NombreDep":
                    switch (SortOrder)
                    {
                        case "Asc":
                            departamentos = departamentos.OrderBy(x => x.NombreDep).ToList();
                            break;
                        case "Desc":
                            departamentos = departamentos.OrderByDescending(x => x.NombreDep).ToList();
                            break;
                    }
                    break;
                case "CodigoEmp":
                    switch (SortOrder)
                    {
                        case "Asc":
                            departamentos = departamentos.OrderBy(x => x.Empleado1.Nombre).ToList();
                            break;
                        case "Desc":
                            departamentos = departamentos.OrderByDescending(x => x.Empleado1.Nombre).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    departamentos = departamentos.OrderBy(x => x.CodigoDep).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(dldn.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            departamentos = departamentos.Skip((page - 1) * 10).Take(10);
            return View(departamentos);

            /*var x = dldn.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);*/
        }
    }
}