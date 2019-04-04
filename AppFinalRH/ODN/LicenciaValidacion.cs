using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODN
{
    public class LicenciaValidacion
    {
 
        public int EmpleadoId { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Desde { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Hasta { get; set; }

        public string Motivo { get; set; }
        [Required]
        public string Comentarios { get; set; }

        public virtual Empleado Empleado { get; set; }
    }


    [MetadataType(typeof(LicenciaValidacion))]
    public partial class Licencia
    {

    }
}
