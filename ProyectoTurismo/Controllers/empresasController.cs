using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTurismo.DAL;
using ProyectoTurismo.Models;

namespace ProyectoTurismo.Controllers
{
    public class empresasController : Controller
    {
        private DBTurismo db = new DBTurismo();
        CuentaController cuenta = new CuentaController();
        string nombre = CuentaController.nombre;

        [HttpPost]
        public ActionResult CompartirSitio(compartir comp) {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into compartir (idSitio,username,usernameCompartir) values('" + comp.idSitio + "'" + ",'" + nombre + "','" + comp.usernameCompartir+ "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CompartirEmpresa(compartir comp)
        {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into compartir (idEmpresa,username,usernameCompartir) values('" + comp.idEmpresa + "'" + ",'" + nombre + "','" + comp.usernameCompartir + "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public  ActionResult IngresarComentario(string comentario, string idSitio) {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into sitio_comentario (idSitio,comentario,usuario) values('" + idSitio+"'"+ ",'"+comentario+"','"+nombre+"')";
            comando = new SqlCommand(sql,cnn);
            adaptador.InsertCommand = new SqlCommand(sql,cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();

                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult IngresarComentarioEmpresa(string comentario, string idEmpresa)
        {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into sitio_comentario (idEmpresa,comentario,usuario) values('" + idEmpresa + "'" + ",'" + comentario + "','" + nombre + "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult IngresarFavorito( string idSitio)
        {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into favorito (idSitio,username) values('" + idSitio + "'" + ",'" + nombre + "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult IngresarFavoritoEmpresa(string idEmpresa)
        {
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "insert into favorito (idEmpresa,username) values('" + idEmpresa + "'" + ",'" + nombre + "')";
            comando = new SqlCommand(sql, cnn);
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            comando.Dispose();
            cnn.Close();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult LikeSitio(string idSitio)
        {
            int megusta=0;
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "select megusta.megusta from megusta where megusta.idSitio="+idSitio+"";
            comando = new SqlCommand(sql, cnn);
            megusta = Convert.ToInt32(comando.ExecuteScalar());
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            if (megusta == 0)
            {
                sql = "insert into megusta (idSitio,megusta) values(" + idSitio + "," + 1 + ")";
                comando = new SqlCommand(sql, cnn);
                adaptador.InsertCommand = new SqlCommand(sql, cnn);
                adaptador.InsertCommand.ExecuteNonQuery();
                comando.Dispose();
                cnn.Close();
            }
            else {
                megusta = megusta + 1;
                sql = "Update megusta set megusta.megusta=" + megusta + "where megusta.idSitio=" + idSitio + "";
                comando = new SqlCommand(sql, cnn);
                adaptador.InsertCommand = new SqlCommand(sql, cnn);
                adaptador.InsertCommand.ExecuteNonQuery();
                comando.Dispose();
                cnn.Close();
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult LikeEmpresa(string idEmpresa)
        {
            int megusta = 0;
            string conexion;
            SqlConnection cnn;
            conexion = @"Data Source=EDSON; Initial Catalog=DBTurismo;integrated security=True;";
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando;
            SqlDataAdapter adaptador = new SqlDataAdapter();
            String sql = "";
            sql = "select megusta.megusta from megusta where megusta.idEmpresa=" + idEmpresa + "";
            comando = new SqlCommand(sql, cnn);
            megusta = Convert.ToInt32(comando.ExecuteScalar());
            adaptador.InsertCommand = new SqlCommand(sql, cnn);
            adaptador.InsertCommand.ExecuteNonQuery();
            if (megusta == 0)
            {
                sql = "insert into megusta (idEmpresa,megusta) values(" + idEmpresa + "," + 1 + ")";
                comando = new SqlCommand(sql, cnn);
                adaptador.InsertCommand = new SqlCommand(sql, cnn);
                adaptador.InsertCommand.ExecuteNonQuery();
                comando.Dispose();
                cnn.Close();
            }
            else
            {
                megusta = megusta + 1;
                sql = "Update megusta set megusta.megusta=" + megusta + "where megusta.idEmpresa=" + idEmpresa + "";
                comando = new SqlCommand(sql, cnn);
                adaptador.InsertCommand = new SqlCommand(sql, cnn);
                adaptador.InsertCommand.ExecuteNonQuery();
                comando.Dispose();
                cnn.Close();
            }
            return RedirectToAction("Index", "Home");

        }
        // GET: empresas
        public ActionResult Index()
        {
            var empresas = db.empresas.Include(e => e.tipoEmpresa);
            return View(empresas.ToList());
        }

        // GET: empresas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: empresas/Create
        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.tipoEmpresas, "idTipo", "nombre");
            return View();
        }

        // POST: empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpresa,idTipo,nombre,direccion,telefono,correo,estado,foto,horario,tarifa,fechaCreacion,fechaAuto")] empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.empresas.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.tipoEmpresas, "idTipo", "nombre", empresa.idTipo);
            return View(empresa);
        }

        // GET: empresas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.tipoEmpresas, "idTipo", "nombre", empresa.idTipo);
            return View(empresa);
        }

        // POST: empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpresa,idTipo,nombre,direccion,telefono,correo,estado,foto,horario,tarifa,fechaCreacion,fechaAuto")] empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.tipoEmpresas, "idTipo", "nombre", empresa.idTipo);
            return View(empresa);
        }

        // GET: empresas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            empresa empresa = db.empresas.Find(id);
            db.empresas.Remove(empresa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
