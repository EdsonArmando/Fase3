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
    public class especialidad_EmpresaController : Controller
    {
        private DBTurismo db = new DBTurismo();

        // GET: especialidad_Empresa
        public ActionResult Index()
        {
            return View(db.especialidad_Empresa.ToList());
        }

        // GET: especialidad_Empresa/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Empresa especialidad_Empresa = db.especialidad_Empresa.Find(id);
            if (especialidad_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Empresa);
        }

        // GET: especialidad_Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: especialidad_Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEspecialidad,idEmpresa")] especialidad_Empresa especialidad_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.especialidad_Empresa.Add(especialidad_Empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad_Empresa);
        }

        // GET: especialidad_Empresa/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Empresa especialidad_Empresa = db.especialidad_Empresa.Find(id);
            if (especialidad_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Empresa);
        }

        // POST: especialidad_Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEspecialidad,idEmpresa")] especialidad_Empresa especialidad_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad_Empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad_Empresa);
        }

        // GET: especialidad_Empresa/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidad_Empresa especialidad_Empresa = db.especialidad_Empresa.Find(id);
            if (especialidad_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Empresa);
        }

        // POST: especialidad_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            especialidad_Empresa especialidad_Empresa = db.especialidad_Empresa.Find(id);
            db.especialidad_Empresa.Remove(especialidad_Empresa);
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
