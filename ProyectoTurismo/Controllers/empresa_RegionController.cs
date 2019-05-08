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
    public class empresa_RegionController : Controller
    {
        private DBTurismo2 db = new DBTurismo2();

        // GET: empresa_Region
        public ActionResult Index()
        {
            return View(db.empresa_Region.ToList());
        }

        // GET: empresa_Region/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa_Region empresa_Region = db.empresa_Region.Find(id);
            if (empresa_Region == null)
            {
                return HttpNotFound();
            }
            return View(empresa_Region);
        }

        // GET: empresa_Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empresa_Region/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRegion,idEmpresa")] empresa_Region empresa_Region)
        {
            if (ModelState.IsValid)
            {
                db.empresa_Region.Add(empresa_Region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa_Region);
        }

        // GET: empresa_Region/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa_Region empresa_Region = db.empresa_Region.Find(id);
            if (empresa_Region == null)
            {
                return HttpNotFound();
            }
            return View(empresa_Region);
        }

        // POST: empresa_Region/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRegion,idEmpresa")] empresa_Region empresa_Region)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa_Region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa_Region);
        }

        // GET: empresa_Region/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa_Region empresa_Region = db.empresa_Region.Find(id);
            if (empresa_Region == null)
            {
                return HttpNotFound();
            }
            return View(empresa_Region);
        }

        // POST: empresa_Region/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empresa_Region empresa_Region = db.empresa_Region.Find(id);
            db.empresa_Region.Remove(empresa_Region);
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
