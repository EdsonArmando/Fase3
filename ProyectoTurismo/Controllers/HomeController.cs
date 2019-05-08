using ProyectoTurismo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class HomeController : Controller
    {
        private DBTurismo db = new DBTurismo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AgentePanel()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TecnicoPanel()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdministradorPanel()
        {
            var usuarios = new DBTurismo();
            ViewBag.Message = "Your contact page.";
            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre");
            return View(usuarios.usuarios.ToList());
        }
       
    }
}