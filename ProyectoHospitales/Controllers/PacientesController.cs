using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProyectoHospitales;

namespace ProyectoHospitales.Controllers
{
    public class PacientesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Pacientes
        public ActionResult Index(string searchString)
        {
            var pacientes = from p in db.Pacientes
                            select p;

            if (!string.IsNullOrEmpty(searchString))
                pacientes = pacientes.Where(s => s.Cedula.Contains(searchString));

            return View(pacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.generos = GetGeneros();
            ViewBag.bloodTypes = GetBloodTypes();
            ViewBag.cities = GetCities();
            return View();
        }

        private List<string> GetBloodTypes()
        {
            var bloodTypes = new List<string>();
            bloodTypes.Add("O-");
            bloodTypes.Add("O+");
            bloodTypes.Add("A+");
            bloodTypes.Add("A-");
            bloodTypes.Add("B+");
            bloodTypes.Add("B-");
            bloodTypes.Add("AB+");
            bloodTypes.Add("AB-");

            return bloodTypes;
        }

        private List<string> GetGeneros()
        {
            var generos = new List<string>();
            generos.Add("Masculino");
            generos.Add("Femenino");

            return generos;
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
            for(int i = 0;i <= 120; i++)
                years.Add(initialYear - i);

            return years;
        }

        private int CalculateAge(Pacientes paciente)
        {
            return DateTime.Now.Year - paciente.Ano_Nacimiento;
        }

        private List<string> GetCities()
        {
            var cities = new List<string>();
            foreach (var x in new Provincias().provincias.Split(','))
                cities.Add(x);

            return cities;
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Paciente,Nombre,Cedula,Apellido,Telefono,Genero,Ciudad,Sector,Calle,C__Residencia,Dia_Nacimiento,Mes_Nacimiento,Ano_Nacimiento,Email,NSS,Tipo_Sangre")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                pacientes.Edad = CalculateAge(pacientes);
                pacientes.Fecha_Nacimiento = pacientes.Mes_Nacimiento.ToString() + "/" + pacientes.Dia_Nacimiento.ToString() + "/" + pacientes.Ano_Nacimiento.ToString();
                db.Pacientes.Add(pacientes);
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
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.generos = GetGeneros();
            ViewBag.bloodTypes = GetBloodTypes();
            ViewBag.cities = GetCities();
            return View(pacientes);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.generos = GetGeneros();
            ViewBag.bloodTypes = GetBloodTypes();
            ViewBag.cities = GetCities();
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Paciente,Nombre,Cedula,Apellido,Telefono,Genero,Edad,Ciudad,Sector,Calle,C__Residencia,Dia_Nacimiento,Mes_Nacimiento,Ano_Nacimiento,Email,NSS,Tipo_Sangre")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                pacientes.Edad = CalculateAge(pacientes);
                pacientes.Fecha_Nacimiento = pacientes.Mes_Nacimiento.ToString() + "/" + pacientes.Dia_Nacimiento.ToString() + "/" + pacientes.Ano_Nacimiento.ToString();
                db.Entry(pacientes).State = EntityState.Modified;
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
            ViewBag.dias = GetDays();
            ViewBag.years = GetYears();
            ViewBag.generos = GetGeneros();
            ViewBag.bloodTypes = GetBloodTypes();
            ViewBag.cities = GetCities();
            return View(pacientes);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            db.Pacientes.Remove(pacientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<Citas> DeleteAllCitas(int id)
        {
            List<Citas> citas = new List<Citas>();
            foreach (var cita in db.Citas)
                if (cita.ID_Paciente == id)
                    citas.Add(db.Citas.Remove(cita));
            db.SaveChanges();
            return citas;
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
