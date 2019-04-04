using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class DepaValidacion
    {
        public string CodigoDep { get; set; }
        [Required]
        public string NombreDep { get; set; }
        public Nullable<int> Encargado { get; set; }
        
    }

    [MetadataType(typeof(DepaValidacion))]
    public partial class Departamento
    {

    }
}
