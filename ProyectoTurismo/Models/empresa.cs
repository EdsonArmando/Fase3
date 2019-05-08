namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("empresa")]
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            reciboes = new HashSet<recibo>();
            regions = new HashSet<region>();
            especialidads = new HashSet<especialidad>();
            servicios = new HashSet<servicio>();
            recorridoes = new HashSet<recorrido>();
        }

        [Key]
        [StringLength(255)]
        public string idEmpresa { get; set; }

        public int idTipo { get; set; }

        [StringLength(255)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string direccion { get; set; }

        [StringLength(255)]
        public string telefono { get; set; }

        [StringLength(255)]
        public string correo { get; set; }

        [StringLength(255)]
        public string estado { get; set; }

        [StringLength(255)]
        public string foto { get; set; }

        [StringLength(255)]
        public string horario { get; set; }

        [StringLength(255)]
        public string tarifa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaAuto { get; set; }


        public virtual tipoEmpresa tipoEmpresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo> reciboes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<region> regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<especialidad> especialidads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicio> servicios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recorrido> recorridoes { get; set; }
    }
}
