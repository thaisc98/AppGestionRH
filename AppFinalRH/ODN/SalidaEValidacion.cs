using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class SalidaEValidacion
    {
      
        public Nullable<int> EmpleadoId { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Motivo { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime FechaSalida { get; set; }

        public virtual Empleado Empleado { get; set; }
    }


    [MetadataType(typeof(SalidaEValidacion))]
    public partial class SalidaEmpleado
    {

    }
}
