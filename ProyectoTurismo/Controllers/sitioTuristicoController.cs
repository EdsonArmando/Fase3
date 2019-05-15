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
    public class sitioTuristicoController : Controller
    {
        private DBTurismo db = new DBTurismo();

        // GET: sitioTuristico
        public ActionResult Index()
        {
            var sitioTuristicoes = db.sitioTuristicoes.Include(s => s.region);
            return View(sitioTuristicoes.ToList());
        }

        // GET: sitioTuristico/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sitioTuristico sitioTuristico = db.sitioTuristicoes.Find(id);
            if (sitioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(sitioTuristico);
        }

        // GET: sitioTuristico/Create
        public ActionResult Create()
        {
            ViewBag.idRegion = new SelectList(db.regions, "idRegion", "nombre");
            return View();
        }

        // POST: sitioTuristico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSitio,idRegion,nombre,descripcion,estado,foto")] sitioTuristico sitioTuristico)
        {
            if (ModelState.IsValid)
            {
                db.sitioTuristicoes.Add(sitioTuristico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRegion = new SelectList(db.regions, "idRegion", "nombre", sitioTuristico.idRegion);
            return View(sitioTuristico);
        }

        // GET: sitioTuristico/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sitioTuristico sitioTuristico = db.sitioTuristicoes.Find(id);
            if (sitioTuristico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRegion = new SelectList(db.regions, "idRegion", "nombre", sitioTuristico.idRegion);
            return View(sitioTuristico);
        }

        // POST: sitioTuristico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSitio,idRegion,nombre,descripcion,estado,foto")] sitioTuristico sitioTuristico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitioTuristico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRegion = new SelectList(db.regions, "idRegion", "nombre", sitioTuristico.idRegion);
            return View(sitioTuristico);
        }

        // GET: sitioTuristico/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sitioTuristico sitioTuristico = db.sitioTuristicoes.Find(id);
            if (sitioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(sitioTuristico);
        }

        // POST: sitioTuristico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sitioTuristico sitioTuristico = db.sitioTuristicoes.Find(id);
            db.sitioTuristicoes.Remove(sitioTuristico);
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
