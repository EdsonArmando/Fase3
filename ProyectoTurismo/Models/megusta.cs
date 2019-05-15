namespace ProyectoTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("megusta")]
    public partial class megusta
    {
        [Key]
        public int idMeguta { get; set; }

        [StringLength(255)]
        public string idEmpresa { get; set; }

        [StringLength(255)]
        public string idSitio { get; set; }

        [Column("megusta")]
        public int? megusta1 { get; set; }
    }
}
