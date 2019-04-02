using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class VacacionValidacion
    {
        
        public Nullable<int> EmpleadoId { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Desde { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Hasta { get; set; }

        [Required]
        public string Comentarios { get; set; }

        public virtual Empleado Empleado { get; set; }
    }

    [MetadataType(typeof(VacacionValidacion))]
    public partial class Vacacion
    {

    }

    
}
