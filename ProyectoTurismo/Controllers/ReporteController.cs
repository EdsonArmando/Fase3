using ProyectoTurismo.DAL;
using ProyectoTurismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class ReporteController : Controller
    {
        private DBTurismo db = new DBTurismo();
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sitio(string region)
        {
            var consulta = from s in db.sitioTuristicoes
                           join re in db.regions on s.idRegion equals re.idRegion
                           where re.nombre==region
                           select new ModeloConsultas { sitioTuristico = s , region = re };
            return View(consulta);
        }
        [HttpPost]
        public ActionResult Empresa(string region)
        {
            var consulta = from e in db.empresas
                           from r in db.regions
                           from re in db.empresa_Region
                           where e.idEmpresa==re.idEmpresa
                           where r.idRegion == re.idRegion
                           where r.nombre == region
                           select new ModeloConsultas { empresa = e, region = r, empresa_Region = re };
            return View(consulta);
        }
        [HttpPost]
        public ActionResult Tipo(string tipo)
        {
            var consulta = from e in db.empresas
                           from t in db.tipoEmpresas
                           where e.idTipo == t.idTipo
                           where t.nombre == tipo
                           select new ModeloConsultas { empresa = e, tipoEmpresa = t};
            return View(consulta);
        }
        [HttpPost]
        public ActionResult Estado(string estado)
        {
            var consulta = from e in db.empresas
                           where e.estado == estado
                           select new ModeloConsultas { empresa = e };
            return View(consulta);
        }
        [HttpPost]
        public ActionResult Recorrido(DateTime fecha)
        {
            var consulta = from r in db.recorridoes
                           where r.fechaInicio == fecha
                           select new ModeloConsultas { recorrido = r };
            return View(consulta);
        }
        [HttpPost]
        public ActionResult TecnicoVisita(string dpi)
        {
            var consulta = from r in db.recorridoes
                           from u in db.usuarios
                           from re in db.recorrido_Empresa
                           from e in db.empresas
                           where r.dpi == u.dpi
                           where re.idRecorrido == r.idRecorrido
                           where e.idEmpresa == re.idEmpresa
                           where r.dpi == dpi
                           select new ModeloConsultas { recorrido = r , usuario = u, recorrido_Empresa = re , empresa = e};
            return View(consulta);
        }
        [HttpPost]
        public ActionResult HotelSer(string region)
        {
            var consulta = from e in db.empresas
                           join es in db.especialidad_Servicio on e.idEmpresa equals es.idEmpresa
                           join s in db.servicios on es.idServicio equals s.idServicio
                           join em in db.empresa_Region on e.idEmpresa equals em.idEmpresa
                           join r in db.regions on em.idRegion equals r.idRegion
                           where r.nombre == region                      
                           select new ModeloConsultas {
                               
                               empresa = e, servicio = s, especialidad_Servicio = es, region = r, empresa_Region = em
                           };
            return View(consulta);
        }
 
        public ActionResult ListadoSitio()
        {
            var consulta = from s in db.sitioTuristicoes
                           from r in db.regions
                           where s.idRegion == r.idRegion
                          
                           select new ModeloConsultas { sitioTuristico = s, region = r                   
                           };
            return View(consulta);
        }
        public ActionResult ListadoEmpresa()
        {
            var consulta = from e in db.empresas
                           from ti in db.tipoEmpresas
                           from em in db.empresa_Region
                           from r in db.regions
                           where e.idTipo == ti.idTipo
                           where e.idEmpresa == em.idEmpresa
                           where em.idRegion == r.idRegion
                           select new ModeloConsultas
                           {
                               empresa = e, tipoEmpresa = ti, empresa_Region = em, region = r
                           };
            return View(consulta);
        }
        [HttpPost]
        public ActionResult EmpresaFecha(DateTime fecha)
        {
            var consulta = from e in db.empresas
                           where e.fechaAuto==fecha
                           select new ModeloConsultas { empresa = e };
            return View(consulta);
        }
    }
}