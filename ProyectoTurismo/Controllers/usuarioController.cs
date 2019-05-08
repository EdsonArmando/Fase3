using ProyectoTurismo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTurismo.Controllers
{
    public class usuarioController : Controller
    {
        private DBTurismo db = new DBTurismo();

        // GET: usuario
        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u => u.rol);
            return View(usuarios.ToList());
        }
       
        // GET: usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuario/Create
        public ActionResult Create()
        {
            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre");
            return View();
        }

        // POST: usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dpi,idRol,nombre,email,telefono,username,contrasenia")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre", usuario.idRol);
            return View(usuario);
        }

        public ActionResult CrearUsuario()
        {
            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre");
            return View();
        } 

        [HttpPost]
        public ActionResult CrearUsuario(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                /* rol rol = db.rols.FirstOrDefault(r => r.Idrol == 2);
                 usuario.rol = rol;*/
                db.usuarios.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " Fue registrado satisfactoriamente.";
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }

        // GET: usuario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // POST: usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dpi,idRol,nombre,email,telefono,username,contrasenia")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRol = new SelectList(db.rols, "Idrol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // GET: usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
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
