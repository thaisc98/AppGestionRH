using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODN
{
    public class PermisoValidacion
    {
        
        public int EmpleadoId { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Desde { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Hasta { get; set; }
        [Required]
        public string Comentarios { get; set; }

    }

    [MetadataType(typeof(PermisoValidacion))]
    public partial class Permiso
    {

    }
}
