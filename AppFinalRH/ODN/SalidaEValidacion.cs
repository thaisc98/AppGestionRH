using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class SalidaEValidacion
    {
      
        public Nullable<int> EmpleadoId { get; set; }
        public string Tipo { get; set; }
        [Required]
        public string Motivo { get; set; }
        public System.DateTime FechaSalida { get; set; }
    }


    [MetadataType(typeof(SalidaEmpleado))]
    public partial class SalidaEmpleado
    {

    }
}
