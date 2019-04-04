using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{
    public class EmpleadoValidacion
    {
        [Required]
        public string CodigoEmp { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Range(18,100, ErrorMessage = "La edad debe estar entre 18 y 100.")]
        public int Edad { get; set; }
        [Required]
        public string Telefono { get; set; }
        
        public Nullable<int> DepartamentoId { get; set; }
        
        public Nullable<int> CargoId { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime FechaIngreso { get; set; }
        [Required]
        public decimal Salario { get; set; }

        public string Estatus { get; set; }
    }

    [MetadataType(typeof(EmpleadoValidacion))]
    public partial class Empleado
    {

    }
}
