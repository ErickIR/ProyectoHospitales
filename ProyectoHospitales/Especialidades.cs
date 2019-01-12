namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Especialidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidades()
        {
            Medico_Especialidad = new HashSet<Medico_Especialidad>();
        }

        [Key]
        public int ID_Especialidad { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico_Especialidad> Medico_Especialidad { get; set; }
    }
}
