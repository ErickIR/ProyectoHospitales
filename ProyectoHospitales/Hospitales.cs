namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hospitales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hospitales()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int ID_Hospital { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Ciudad { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Sector { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Calle { get; set; }

        [Column("#_Residencia")]
        public int? C__Residencia { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
    }
}
