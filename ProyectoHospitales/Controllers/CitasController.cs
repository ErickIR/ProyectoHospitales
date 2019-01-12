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
    public class CitasController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Citas
        public ActionResult Index(string stringSearch)
        {
            var citas = db.Citas.Include(c => c.Hospitales).Include(c => c.Medicos).Include(c => c.Pacientes);



            if (!string.IsNullOrEmpty(stringSearch))
            {
                var med = GetMedico(stringSearch);
                citas = citas.Where(c => c.ID_Medico == med.ID_Medico);
            }

            ViewBag.cedulas = GetCedulas();
            return View(citas);
        }
        
        private Medicos GetMedico(string search)
        {
            foreach (var med in db.Medicos)
                if (med.Cedula == search)
                    return med;
            return null;
        }

        private List<string> GetCedulas()
        {
            var names = new List<string>();
            foreach (var medico in db.Medicos)
                names.Add(medico.Cedula);
            return names;
        }

        public ActionResult FindPaciente()
        {
            return null;
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hospital = new SelectList(db.Hospitales, "ID_Hospital", "Nombre");
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre");
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre");
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.hours = GetHour();
            ViewBag.mins = GetMin();
            return View();
        }

        private List<int> GetDays()
        {
            var dias = new List<int>();
            var valorDia = new ValoresDia().ValorDia.Split(',');
            foreach (var x in valorDia)
                dias.Add(int.Parse(x));

            return dias;
        }

        private List<int> GetYears()
        {
            var years = new List<int>();
            var initialYear = DateTime.Now.Year;
            for (int i = 0; i <= 2; i++)
                years.Add(initialYear + i);

            return years;
        }

        private List<string> GetHour()
        {
            var hours = new List<string>();
            for(int i = 0;i <= 23; i++)
                hours.Add(i.ToString());

            return hours;
        }

        private List<string> GetMin()
        {
            var mins = new List<string>();
            for (int i = 0; i <= 59; i++)
                mins.Add(i.ToString());

            return mins;
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cita,ID_Paciente,ID_Medico,ID_Hospital,Fecha_Agendada,Descripcion, Dia, Mes, Año, Hora, Minutos, Hora_Completa")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                citas.Hora_Completa = citas.Hora + ":" + citas.Minutos;
                citas.Fecha_Agendada = citas.Dia.ToString() + "/" + citas.Mes.ToString() + "/" + citas.Año.ToString();
                db.Citas.Add(citas);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    Redirect("http://localhost:57776/Pacientes");
                    return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                    //return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                }
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hospital = new SelectList(db.Hospitales, "ID_Hospital", "Nombre", citas.ID_Hospital);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", citas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre", citas.ID_Paciente);
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.hours = GetHour();
            ViewBag.mins = GetMin();
            return View(citas);
        }

       

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hospital = new SelectList(db.Hospitales, "ID_Hospital", "Nombre", citas.ID_Hospital);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", citas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre", citas.ID_Paciente);
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.hours = GetHour();
            ViewBag.mins = GetMin();
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cita,ID_Paciente,ID_Medico,ID_Hospital,Fecha_Agendada,Descripcion, Dia, Mes, Año")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                citas.Hora_Completa = citas.Hora + ":" + citas.Minutos;
                citas.Fecha_Agendada = citas.Dia.ToString() + "/" + citas.Mes.ToString() + "/" + citas.Año.ToString();
                db.Entry(citas).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    Redirect("http://localhost:57776/Pacientes");
                    return Content("<script language='javascript' type='text/javascript'>alert('Hubo un error al guardar en la base de datos. Vuelva a la pagina principal!');</script>");
                }
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hospital = new SelectList(db.Hospitales, "ID_Hospital", "Nombre", citas.ID_Hospital);
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre", citas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre", citas.ID_Paciente);
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.hours = GetHour();
            ViewBag.mins = GetMin();
            return View(citas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
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

        private List<Citas> findPaciente(string Nombre_Completo)
        {
            List<Citas> citas = new List<Citas>();
            foreach (var cita in db.Citas)
            {
                string Nombre_Apellido = cita.Pacientes.Nombre + cita.Pacientes.Apellido;
                if (Nombre_Apellido == Nombre_Completo)
                {
                    citas.Add(cita);
                }

            }
            return citas;
        }
    }
}
