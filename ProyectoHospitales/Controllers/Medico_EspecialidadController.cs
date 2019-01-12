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
    public class Medico_EspecialidadController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Medico_Especialidad
        public ActionResult Index()
        {
            var medico_Especialidad = db.Medico_Especialidad.Include(m => m.Especialidades).Include(m => m.Medicos);
            return View(medico_Especialidad.ToList());
        }

        // GET: Medico_Especialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico_Especialidad medico_Especialidad = db.Medico_Especialidad.Find(id);
            if (medico_Especialidad == null)
            {
                return HttpNotFound();
            }
            return View(medico_Especialidad);
        }

        // GET: Medico_Especialidad/Create
        public ActionResult Create()
        {
            ViewBag.ID_Especialidad = new SelectList(db.Especialidades, "ID_Especialidad", "Nombre");
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre");
            return View();
        }

        // POST: Medico_Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MedicoEspecialidad,ID_Medico,ID_Especialidad")] Medico_Especialidad medico_Especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Medico_Especialidad.Add(medico_Especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Especialidad = new SelectList(db.Especialidades, "ID_Especialidad", "Nombre", medico_Especialidad.ID_Especialidad);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", medico_Especialidad.ID_Medico);
            return View(medico_Especialidad);
        }

        // GET: Medico_Especialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico_Especialidad medico_Especialidad = db.Medico_Especialidad.Find(id);
            if (medico_Especialidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Especialidad = new SelectList(db.Especialidades, "ID_Especialidad", "Nombre", medico_Especialidad.ID_Especialidad);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", medico_Especialidad.ID_Medico);
            return View(medico_Especialidad);
        }

        // POST: Medico_Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MedicoEspecialidad,ID_Medico,ID_Especialidad")] Medico_Especialidad medico_Especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico_Especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Especialidad = new SelectList(db.Especialidades, "ID_Especialidad", "Nombre", medico_Especialidad.ID_Especialidad);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", medico_Especialidad.ID_Medico);
            return View(medico_Especialidad);
        }

        // GET: Medico_Especialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico_Especialidad medico_Especialidad = db.Medico_Especialidad.Find(id);
            if (medico_Especialidad == null)
            {
                return HttpNotFound();
            }
            return View(medico_Especialidad);
        }

        // POST: Medico_Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico_Especialidad medico_Especialidad = db.Medico_Especialidad.Find(id);
            db.Medico_Especialidad.Remove(medico_Especialidad);
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
