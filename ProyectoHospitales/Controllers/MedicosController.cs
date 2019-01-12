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
    public class MedicosController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Medicos
        public ActionResult Index(string searchString)
        {
            var medicos = from m in db.Medicos
                          select m;
            if (!string.IsNullOrEmpty(searchString))
                medicos = medicos.Where(s => s.Cedula.Contains(searchString));

            ViewBag.cedulas = GetCedulas();
            return View(medicos);
        }
        
        public List<string> GetCedulas()
        {
            var cedulas = new List<string>();
            foreach (var med in db.Medicos)
                cedulas.Add(med.Cedula);

            return cedulas;
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.cities = GetCities();
            return View();
        }

        private List<string> GetCities()
        {
            var cities = new List<string>();
            foreach (var x in new Provincias().provincias.Split(','))
                cities.Add(x);

            return cities;
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Medico,Nombre,Apellido,Cedula,Ciudad,Sector,Calle,C__Residencia,Telefono")] Medicos medicos)
        {
            
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medicos);
                try
                {
                    db.SaveChanges();
                }catch (Exception)
                {
                    Redirect("http://localhost:57776/Medicos");
                    return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                }
                return RedirectToAction("Index");
            }
            ViewBag.cities = GetCities();
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.cities = GetCities();
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Medico,Nombre,Apellido,Cedula,Ciudad,Sector,Calle,C__Residencia,Telefono")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    Redirect("http://localhost:57776/Medicos");
                    return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                    //return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                }
                return RedirectToAction("Index");
            }
            ViewBag.cities = GetCities();
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicos medicos = db.Medicos.Find(id);
            var citas = DeleteAllCitas(id);
            var especialidades = DeleteAllEspecialidades(id);
            db.Medicos.Remove(medicos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<Citas> DeleteAllCitas(int id)
        {
            List<Citas> citas = new List<Citas>();
            foreach (var cita in db.Citas)
                if (cita.ID_Medico == id)
                    citas.Add(db.Citas.Remove(cita));
            db.SaveChanges();
            return citas;
        }

        private List<Medico_Especialidad> DeleteAllEspecialidades(int id)
        {
            var especialidades = new List<Medico_Especialidad>();
            foreach (var especialidad in db.Medico_Especialidad)
                if (especialidad.ID_Medico == id)
                    especialidades.Add(db.Medico_Especialidad.Remove(especialidad));
            db.SaveChanges();
            return especialidades;
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
