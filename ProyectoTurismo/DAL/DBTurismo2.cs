namespace ProyectoTurismo.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBTurismo2 : DbContext
    {
        public DBTurismo2()
            : base("name=DBTurismo2")
        {
        }

        public virtual DbSet<empresa_Region> empresa_Region { get; set; }
        public virtual DbSet<especialidad_Empresa> especialidad_Empresa { get; set; }
        public virtual DbSet<especialidad_Servicio> especialidad_Servicio { get; set; }
        public virtual DbSet<recorrido_Empresa> recorrido_Empresa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<empresa_Region>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad_Empresa>()
                .Property(e => e.idEspecialidad)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad_Empresa>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad_Servicio>()
                .Property(e => e.idServicio)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad_Servicio>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<recorrido_Empresa>()
                .Property(e => e.idRecorrido)
                .IsUnicode(false);

            modelBuilder.Entity<recorrido_Empresa>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);
        }
    }
}
