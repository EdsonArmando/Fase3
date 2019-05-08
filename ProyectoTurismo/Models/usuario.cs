namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            recorridoes = new HashSet<recorrido>();
        }

        [Key]
        [StringLength(255)]
        public string dpi { get; set; }

        public int idRol { get; set; }

        [StringLength(255)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string telefono { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string contrasenia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recorrido> recorridoes { get; set; }

        public virtual rol rol { get; set; }
    }
}
