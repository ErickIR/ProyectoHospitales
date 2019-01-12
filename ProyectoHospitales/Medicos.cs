namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medicos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicos()
        {
            Citas = new HashSet<Citas>();
            Medico_Especialidad = new HashSet<Medico_Especialidad>();
        }

        [Key]
        public int ID_Medico { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^\d+$")]
        [CorrectCedula]
        public string Cedula { get; set; }

        [Required]
        [StringLength(255)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Text)]
        public string Sector { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Text)]
        public string Calle { get; set; }

        [Column("#_Residencia")]
        public int C__Residencia { get; set; }

        [Required]
        [StringLength(10)]
        [CorrectPhone]
        public string Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico_Especialidad> Medico_Especialidad { get; set; }
    }
}
