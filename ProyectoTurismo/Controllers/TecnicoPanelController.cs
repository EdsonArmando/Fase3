using ProyectoTurismo.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class TecnicoPanelController : Controller
    {
        CuentaController cuenta = new CuentaController();
        public DBTurismo db = new DBTurismo();
        // GET: TecnicoPanel
        public ActionResult Index()
        {
            return View();
        }

        
    }
}