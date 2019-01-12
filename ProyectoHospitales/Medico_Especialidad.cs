namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medico_Especialidad
    {
        [Key]
        public int ID_MedicoEspecialidad { get; set; }

        public int? ID_Medico { get; set; }

        public int? ID_Especialidad { get; set; }

        public virtual Especialidades Especialidades { get; set; }

        public virtual Medicos Medicos { get; set; }
    }
}
