using LDN;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Informe.Controllers
{
    [Authorize(Roles = "A")]
    public class CargoIController : Controller
    {
        private CargoLDN c;

        public CargoIController() => c = new CargoLDN();

        // GET: Informe/CargoI
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
             ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var cargos = c.GetAll();

            switch (SortBy)
            {
                case "CodigoCargo":
                    switch (SortOrder)
                    {
                        case "Asc":
                            cargos = cargos.OrderBy(x => x.CodigoCargo).ToList();
                            break;
                        case "Desc":
                            cargos = cargos.OrderByDescending(x => x.CodigoCargo).ToList();
                            break;
                    }
                    break;
                case "NombreCargo":
                    switch (SortOrder)
                    {
                        case "Asc":
                            cargos = cargos.OrderBy(x => x.NombreCargo).ToList();
                            break;
                        case "Desc":
                            cargos = cargos.OrderByDescending(x => x.NombreCargo).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    cargos = cargos.OrderBy(x => x.CodigoCargo).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(c.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            cargos = cargos.Skip((page - 1) * 10).Take(10);
            return View(cargos);

          /*  var x = c.GetAll();

            ViewBag.TotalPages = Math.Ceiling(x.Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            x = x.Skip((page - 1) * 10).Take(10);


            return View(x);*/
        }
    }
}