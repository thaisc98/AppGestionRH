using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODN
{
    public class SalidaEValidacion
    {
      
        public Nullable<int> EmpleadoId { get; set; }
        public string Tipo { get; set; }
        [Required]
        public string Motivo { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaSalida { get; set; }
    }


    [MetadataType(typeof(SalidaEmpleado))]
    public partial class SalidaEmpleado
    {

    }
}
