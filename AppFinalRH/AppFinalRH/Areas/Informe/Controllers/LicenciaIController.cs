using System;
using System.Linq;
using LDN;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class LicenciaIController : Controller
    {
        private LicenciaLDN l;

        public LicenciaIController() => l = new LicenciaLDN();

        // GET: Informe/LicenciaI
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var licencias = l.GetAll();

            switch (SortBy)
            {
                case "Desde":
                    switch (SortOrder)
                    {
                        case "Asc":
                            licencias = licencias.OrderBy(x => x.Desde).ToList();
                            break;
                        case "Desc":
                            licencias = licencias.OrderByDescending(x => x.Desde).ToList();
                            break;
                    }
                    break;
                case "Hasta":
                    switch (SortOrder)
                    {
                        case "Asc":
                            licencias = licencias.OrderBy(x => x.Hasta).ToList();
                            break;
                        case "Desc":
                            licencias = licencias.OrderByDescending(x => x.Hasta).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Motivo":
                    switch (SortOrder)
                    {
                        case "Asc":
                            licencias = licencias.OrderBy(x => x.Motivo).ToList();
                            break;
                        case "Desc":
                            licencias = licencias.OrderByDescending(x => x.Motivo).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Comentarios":
                    switch (SortOrder)
                    {
                        case "Asc":
                            licencias = licencias.OrderBy(x => x.Comentarios).ToList();
                            break;
                        case "Desc":
                            licencias = licencias.OrderByDescending(x => x.Comentarios).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Empleado":
                    switch (SortOrder)
                    {
                        case "Asc":
                            licencias = licencias.OrderBy(x => x.Empleado.Nombre).ToList();
                            break;
                        case "Desc":
                            licencias = licencias.OrderByDescending(x => x.Empleado.Nombre).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    licencias = licencias.OrderBy(x => x.Desde).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(l.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            licencias = licencias.Skip((page - 1) * 10).Take(10);
            return View(licencias);
            /*
            var x = l.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);
            return View(x);*/
        }
    }
}