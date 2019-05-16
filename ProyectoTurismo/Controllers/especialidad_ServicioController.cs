using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTurismo.DAL;

namespace ProyectoTurismo.Controllers
{
    public class especialidad_ServicioController : Controller
    {
        private DBTurismo db = new DBTurismo();

        // GET: especialidad_Servicio
        public ActionResult Index()
        {
            return View(db.especialidad_Servicio.ToList());
        }

        // GET: especialidad_Servicio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Servicio especialidad_Servicio = db.especialidad_Servicio.Find(id);
            if (especialidad_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Servicio);
        }

        // GET: especialidad_Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: especialidad_Servicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio,idEmpresa")] especialidad_Servicio especialidad_Servicio)
        {
            if (ModelState.IsValid)
            {
                db.especialidad_Servicio.Add(especialidad_Servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad_Servicio);
        }

        // GET: especialidad_Servicio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Servicio especialidad_Servicio = db.especialidad_Servicio.Find(id);
            if (especialidad_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Servicio);
        }

        // POST: especialidad_Servicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio,idEmpresa")] especialidad_Servicio especialidad_Servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad_Servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad_Servicio);
        }

        // GET: especialidad_Servicio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Servicio especialidad_Servicio = db.especialidad_Servicio.Find(id);
            if (especialidad_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Servicio);
        }

        // POST: especialidad_Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            especialidad_Servicio especialidad_Servicio = db.especialidad_Servicio.Find(id);
            db.especialidad_Servicio.Remove(especialidad_Servicio);
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
