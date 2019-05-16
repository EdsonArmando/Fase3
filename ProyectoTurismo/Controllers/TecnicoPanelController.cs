using ProyectoTurismo.DAL;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [HttpPost]
        public ActionResult Crear(string idRecorrido, string dpi,string nombre, DateTime fechaInicio, DateTime fechaFin) {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into recorrido (idRecorrido,dpi,nombre,fechaInicio,fechaFin) values('" + idRecorrido + "'" + ",'" + dpi + "','" + nombre + "','" + fechaInicio+ "','"+fechaFin+ "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();
            return RedirectToAction("../Home/TecnicoPanel");
        }
        
    }
}