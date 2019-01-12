using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoHospitales;

namespace ProyectoHospitales.Controllers
{
    public class HospitalesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Hospitales
        public ActionResult Index()
        {
            return View(db.Hospitales.ToList());
        }

        // GET: Hospitales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // GET: Hospitales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Hospital,Nombre,Ciudad,Sector,Calle,C__Residencia,Telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Hospitales.Add(hospitales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitales);
        }

        // GET: Hospitales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // POST: Hospitales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Hospital,Nombre,Ciudad,Sector,Calle,C__Residencia,Telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitales);
        }

        // GET: Hospitales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // POST: Hospitales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospitales hospitales = db.Hospitales.Find(id);
            db.Hospitales.Remove(hospitales);
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
