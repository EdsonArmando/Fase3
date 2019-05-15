namespace ProyectoTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("compartir")]
    public partial class compartir
    {
        [Key]
        public int idCompartir { get; set; }

        [StringLength(255)]
        public string idEmpresa { get; set; }

        [StringLength(255)]
        public string idSitio { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string usernameCompartir { get; set; }
    }
}
