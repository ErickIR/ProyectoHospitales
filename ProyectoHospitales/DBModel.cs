namespace ProyectoHospitales
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Hospitales> Hospitales { get; set; }
        public virtual DbSet<Medico_Especialidad> Medico_Especialidad { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>()
                .Property(e => e.Fecha_Agendada)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidades>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidades>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitales>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitales>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitales>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitales>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Hospitales>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Genero)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.NSS)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Tipo_Sangre)
                .IsUnicode(false);
        }
    }
}
