using ProyectoTurismo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTurismo.Models
{
    public class ModeloConsultas
    {
        public string nombreEmpresa { get; set; }
        public string nombreRegion { get; set; }
        public sitioTuristico sitioTuristico { get; set; }
        public region region { get; set; }
        public empresa empresa { get; set; }
        public empresa_Region empresa_Region { get; set; }
        public tipoEmpresa tipoEmpresa { get; set; }
        public recorrido recorrido { get; set; }
        public usuario usuario { get; set; }
        public recorrido_Empresa recorrido_Empresa { get; set; }
        public servicio servicio { get; set; }
        public especialidad_Servicio especialidad_Servicio { get; set; }
        public favorito favorito { get; set; }
        public compartir compartir { get; set; }
        public sitio_comentario sitio_Comentario { get; set; }
        public megusta megusta { get; set; }
    }
}