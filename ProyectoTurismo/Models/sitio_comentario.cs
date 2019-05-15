namespace ProyectoTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sitio_comentario
    {
        [Key]
        [Column(Order = 0)]
        public int idComentario { get; set; }


     
        [StringLength(255)]
        public string idSitio { get; set; }

        [StringLength(255)]
        public string idEmpresa { get; set; }

        [StringLength(255)]
        public string comentario { get; set; }

        [StringLength(255)]
        public string usuario { get; set; }
    }
}
