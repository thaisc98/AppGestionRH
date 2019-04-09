using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODN
{
    public class UsuarioValidacion
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Contra { get; set; }
        public string Role { get; set; }
    }

    [MetadataType(typeof(UsuarioValidacion))]
    public partial class Usuario
    {

    }
}
