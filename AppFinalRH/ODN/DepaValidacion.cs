using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODN
{
    public class DepaValidacion
    {
        [Required]
        public string CodigoDep { get; set; }
        [Required]
        public string NombreDep { get; set; }
        public Nullable<int> Encargado { get; set; }
        
    }

    [MetadataType(typeof(MetadataTypeAttribute))]
    public partial class Departamento
    {

    }
}
