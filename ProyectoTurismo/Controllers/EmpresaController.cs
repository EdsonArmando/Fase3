using ProyectoTurismo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class EmpresaController : Controller
    {
        DBTurismo db = new DBTurismo();
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult CompartirEm(string id)
        {
            empresa empresa = db.empresas.Find(id);
            return View(empresa);
        }
        public ActionResult CompartirSitio(string id)
        {
            sitioTuristico sitioTuristico = db.sitioTuristicoes.Find(id);
            return View(sitioTuristico);
        }
    }
}