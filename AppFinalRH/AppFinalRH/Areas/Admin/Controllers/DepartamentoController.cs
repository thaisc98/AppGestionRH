using LDN;
using ODN;
using System.Linq;
using System.Web.Mvc;

namespace AppFinalRH.Areas.Admin.Controllers
{
    public class DepartamentoController : Controller
    {
        private DepartamentoLDN depaldn;
        private EmpleadoLDN empleldn;

        public DepartamentoController()
        {
            depaldn = new DepartamentoLDN();
            empleldn = new EmpleadoLDN();
        }

        // GET: Admin/Departamento
        public ActionResult Index()
        {
            var x = depaldn.GetAll();
            return View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Encargado = empleldn.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Nombre + " " + x.Apellido + " (" + x.CodigoEmp + ") ",
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public ActionResult Create(Departamento depa)
        {
            if (ModelState.IsValid)
            {
                depaldn.Insert(depa);
                return RedirectToAction("Index", "Departamento", new {area = "Admin"});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Encargado = empleldn.GetAll().Select(z => new SelectListItem()
            {
                Text = z.Nombre + " " + z.Apellido + " (" + z.CodigoEmp + ") ",
                Value = z.Id.ToString()
            });
            var x = depaldn.GetById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(Departamento depa)
        {
            if (ModelState.IsValid)
            {
                depaldn.Update(depa);
                return RedirectToAction("Index","Departamento",new {area ="Admin"});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                depaldn.Delete(id);
                return RedirectToAction("Index", "Departamento", new {area = "Admin"});
            }
            catch
            {
                TempData["Error"] = "Error al elminar departamento";
                return RedirectToAction("Index", "Departamento", new {area = "Admin"});
            }

        }

    }
}