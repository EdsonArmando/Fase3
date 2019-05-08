namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("recorrido")]
    public partial class recorrido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recorrido()
        {
            empresas = new HashSet<empresa>();
        }

        [Key]
        [StringLength(255)]
        public string idRecorrido { get; set; }

        [Required]
        [StringLength(255)]
        public string dpi { get; set; }

        [StringLength(255)]
        public string nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaFin { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa> empresas { get; set; }
    }
}
