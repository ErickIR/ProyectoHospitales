namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    

    public partial class Pacientes: IValidatableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacientes()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int ID_Paciente { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^\d+$")]
        [CorrectCedula]
        public string Cedula { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        [CorrectPhone]
        public string Telefono { get; set; }

        
        [StringLength(255)]
        public string Genero { get; set; }

        public int Edad { get; set; }

        [StringLength(255)]
        public string Ciudad { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        public string Sector { get; set; }

        [StringLength(255)]
        [DataType(DataType.Text)]
        public string Calle { get; set; }

        [Column("#_Residencia")]
        public int? C__Residencia { get; set; }

        
        public int Dia_Nacimiento { get; set; }
        public ValoresMes Mes_Nacimiento { get; set; }
        public int Ano_Nacimiento { get; set; }

        [StringLength(255)]
        public string Fecha_Nacimiento { get; set; }

        // 1@1.l
        [StringLength(255)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^\d+$")]
        public string NSS { get; set; }

        [Required]
        [StringLength(255)]
        public string Tipo_Sangre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }



        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            int month = (int)Mes_Nacimiento;
            string Fecha = Dia_Nacimiento.ToString() + "/" + month.ToString() + "/" + Ano_Nacimiento.ToString();
            if (Convert.ToDateTime(Fecha) > DateTime.Today)
            {
                ValidationResult mss = new ValidationResult("Invalid BirthDate");

                res.Add(mss);

            }
            return res;
        }
    }
}
