namespace ProyectoTurismo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sitioTuristico")]
    public partial class sitioTuristico
    {
        private DBTurismo db = new DBTurismo();
        [Key]
        [StringLength(255)]
        public string idSitio { get; set; }

        public int idRegion { get; set; }

        [StringLength(255)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [StringLength(255)]
        public string estado { get; set; }

        [StringLength(255)]
        public string foto { get; set; }

        public virtual region region { get; set; }

       
    }
}
