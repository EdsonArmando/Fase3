namespace ProyectoTurismo.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBTurismo : DbContext
    {
        public DBTurismo()
            : base("name=DBTurismoContext")
        {
        }

        public virtual DbSet<empresa> empresas { get; set; }
        public virtual DbSet<especialidad> especialidads { get; set; }
        public virtual DbSet<recibo> reciboes { get; set; }
        public virtual DbSet<recorrido> recorridoes { get; set; }
        public virtual DbSet<region> regions { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<servicio> servicios { get; set; }
        public virtual DbSet<sitioTuristico> sitioTuristicoes { get; set; }
        public virtual DbSet<tipoEmpresa> tipoEmpresas { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<empresa_Region> empresa_Region { get; set; }
        public virtual DbSet<especialidad_Empresa> especialidad_Empresa { get; set; }
        public virtual DbSet<especialidad_Servicio> especialidad_Servicio { get; set; }
        public virtual DbSet<recorrido_Empresa> recorrido_Empresa { get; set; }
        //public System.Data.Entity.DbSet<ProyectoTurismo.DAL.empresa_Region> empresa_Region { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<empresa>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.horario)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.tarifa)
                .IsUnicode(false);

            

            /*modelBuilder.Entity<empresa>()
                .HasMany(e => e.regions)
                .WithMany(e => e.empresas)
                .Map(m => m.ToTable("empresa_Region").MapLeftKey("idEmpresa").MapRightKey("idRegion"));

            modelBuilder.Entity<empresa>()
                .HasMany(e => e.especialidads)
                .WithMany(e => e.empresas)
                .Map(m => m.ToTable("especialidad_Empresa").MapLeftKey("idEmpresa").MapRightKey("idEspecialidad"));

            modelBuilder.Entity<empresa>()
                .HasMany(e => e.servicios)
                .WithMany(e => e.empresas)
                .Map(m => m.ToTable("especialidad_Servicio").MapLeftKey("idEmpresa").MapRightKey("idServicio"));

            modelBuilder.Entity<empresa>()
                .HasMany(e => e.recorridoes)
                .WithMany(e => e.empresas)
                .Map(m => m.ToTable("recorrido_Empresa").MapLeftKey("idEmpresa").MapRightKey("idRecorrido"));*/

            modelBuilder.Entity<especialidad>()
                .Property(e => e.idEspecialidad)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<recibo>()
                .Property(e => e.idRecibo)
                .IsUnicode(false);

            modelBuilder.Entity<recibo>()
                .Property(e => e.idEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<recibo>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<recorrido>()
                .Property(e => e.idRecorrido)
                .IsUnicode(false);

            modelBuilder.Entity<recorrido>()
                .Property(e => e.dpi)
                .IsUnicode(false);

            modelBuilder.Entity<recorrido>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<region>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<region>()
                .HasMany(e => e.sitioTuristicoes)
                .WithRequired(e => e.region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rol>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.usuarios)
                .WithRequired(e => e.rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<servicio>()
                .Property(e => e.idServicio)
                .IsUnicode(false);

            modelBuilder.Entity<servicio>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<sitioTuristico>()
                .Property(e => e.idSitio)
                .IsUnicode(false);

            modelBuilder.Entity<sitioTuristico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<sitioTuristico>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<sitioTuristico>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<sitioTuristico>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<tipoEmpresa>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tipoEmpresa>()
                .HasMany(e => e.empresas)
                .WithRequired(e => e.tipoEmpresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.dpi)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.recorridoes)
                .WithRequired(e => e.usuario)
                .WillCascadeOnDelete(false);
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
