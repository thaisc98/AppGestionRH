using LDN;
using ODN;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class NominaController : Controller
    {
        private NominaLDN nominaLdn;
        private EmpleadoLDN empleadoLdn;

        public NominaController()
        {
            nominaLdn = new NominaLDN();
            empleadoLdn = new EmpleadoLDN();
        }


        // GET: Admin/Nomina
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int? valorMes, int? valorAnio)
        {
            List<SelectListItem> meses = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Enero", Value = "1", Selected = true},
                new SelectListItem() {Text = "Febrero", Value = "2", Selected = false},
                new SelectListItem() {Text = "Marzo", Value = "3", Selected = false},
                new SelectListItem() {Text = "Abril", Value = "4", Selected = false},
                new SelectListItem() {Text = "Mayo", Value = "5", Selected = false},
                new SelectListItem() {Text = "Junio", Value = "6", Selected = false},
                new SelectListItem() {Text = "Julio", Value = "7", Selected = false},
                new SelectListItem() {Text = "Agosto", Value = "8", Selected = false},
                new SelectListItem() {Text = "Septiembre", Value = "9", Selected = false},
                new SelectListItem() {Text = "Octubre", Value = "10", Selected = false},
                new SelectListItem() {Text = "Noviembre", Value = "11", Selected = false},
                new SelectListItem() {Text = "Diciembre", Value = "12", Selected = false}
            };

            ViewBag.ListaMeses = meses;

            List<SelectListItem> anios = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "2019", Value = "2019", Selected = true},
                new SelectListItem() {Text = "2018", Value = "2018", Selected = false},
                new SelectListItem() {Text = "2017", Value = "2017", Selected = false},
                new SelectListItem() {Text = "2016", Value = "2016", Selected = false},
            };

            ViewBag.ListaAnios = anios;

            string elMes = "";

            if (valorMes != null)
            {
                meses.First(x => x.Value == valorMes.ToString()).Selected = true;
            }

            if (valorAnio != null)
            {
                anios.First(x => x.Value == valorAnio.ToString()).Selected = true;
            }
            decimal total = empleadoLdn.GetActives().Sum(x => x.Salario);
            ViewBag.Total = total;

            ViewBag.MesId = new SelectList(empleadoLdn.GetActives(), "Id", "Descripcion");

            return View();
        }


        [HttpPost]
        public ActionResult Create(Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                nomina.MontoT = (empleadoLdn.GetActives().Sum(x => x.Salario));
                nomina.Estatus = "P";

                nominaLdn.Insert(nomina);
                return RedirectToAction("Index", "Nomina");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.MesId = new SelectList(empleadoLdn.GetActives(), "Id", "Descripcion");
            return View(nominaLdn.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                nominaLdn.Update(nomina);
                return RedirectToAction("Index", "Nomina");
            }
            return View(nomina);
        }
    
    }
}