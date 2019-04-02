using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class CargoValidacion
    {
        [Required]
        public string CodigoCargo { get; set; }
        [Required]
        public string NombreCargo { get; set; }
    }
    
    [MetadataType(typeof(CargoValidacion))]
    public partial class Cargo
    {

    }
}
