namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("recibo")]
    public partial class recibo
    {
        [Key]
        [StringLength(255)]
        public string idRecibo { get; set; }

        [StringLength(255)]
        public string idEmpresa { get; set; }

        [StringLength(255)]
        public string estado { get; set; }

        public virtual empresa empresa { get; set; }
    }
}
