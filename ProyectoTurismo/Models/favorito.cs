namespace ProyectoTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("favorito")]
    public partial class favorito
    {
        [Key]
        public int idFavorito { get; set; }

        [StringLength(255)]
        public string idEmpresa { get; set; }

        [StringLength(255)]
        public string idSitio { get; set; }

        [StringLength(255)]
        public string username { get; set; }
    }
}
