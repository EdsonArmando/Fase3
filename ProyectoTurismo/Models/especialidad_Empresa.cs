namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class especialidad_Empresa
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string idEspecialidad { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string idEmpresa { get; set; }
    }
}
