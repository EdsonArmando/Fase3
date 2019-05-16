using ProyectoTurismo.DAL;
using ProyectoTurismo.Models;
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
        string nombre = CuentaController.nombre;
        string dpi = CuentaController.dpi;
        public ActionResult Index()
        {
            var consulta = from s in db.sitioTuristicoes
                           from r in db.regions
                           where s.idRegion == r.idRegion

                           select new ModeloConsultas
                           {
                               sitioTuristico = s,
                               region = r
                           };
            return View(consulta);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult EmpresasView()
        {
            var consulta = from e in db.empresas
                           from r in db.regions
                           from re in db.empresa_Region
                           where e.idEmpresa == re.idEmpresa
                           where r.idRegion == re.idRegion
                           select new ModeloConsultas { empresa = e, region = r, empresa_Region = re };
            return View(consulta);
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
        public ActionResult TuristaPanel()
        {
            var consulta = from f in db.favorito
                           from s in db.sitioTuristicoes

                           where s.idSitio == f.idSitio
                           where f.username == nombre
                           select new ModeloConsultas { favorito = f, sitioTuristico = s };
         
            return View(consulta);
       
        }
        public ActionResult TecnicoPanel()
        {
            var consulta = from e in db.empresas
                           from r in db.regions
                           from em in db.empresa_Region
                           where e.idEmpresa == em.idEmpresa
                           where r.idRegion == em.idRegion
                           select new ModeloConsultas { empresa = e, empresa_Region = em, region = r };

            return View(consulta);
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