namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Citas: IValidatableObject
    {
        [Key]
        public int ID_Cita { get; set; }

        public int? ID_Paciente { get; set; }

        public int? ID_Medico { get; set; }

        public int? ID_Hospital { get; set; }

        [Required]
        [Range(1, 31)]
        public int Dia { get; set; }

        [Required]
        public ValoresMes Mes { get; set; }

        [Required]
        [Range(2019, 2021)]
        public int Año { get; set; }

        [StringLength(255)]
        public string Fecha_Agendada { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [StringLength(255)]
        public string Hora { get; set; }

        [StringLength(255)]
        public string Minutos { get; set; }

        [StringLength(255)]
        public string Hora_Completa { get; set; }

        public virtual Hospitales Hospitales { get; set; }

        public virtual Medicos Medicos { get; set; }

        public virtual Pacientes Pacientes { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            int month = (int)Mes;
            string Fecha = Dia.ToString() + "/" + month.ToString() + "/" + Año.ToString();
            if (Convert.ToDateTime(Fecha) < DateTime.Today || (Convert.ToDateTime(Fecha) == DateTime.Today && int.Parse(Hora) <= DateTime.Now.Hour))
            {
                ValidationResult mss = new ValidationResult("Invalid Booked Date");

                res.Add(mss);

            }
            
            return res;
        }


    }

    
}



