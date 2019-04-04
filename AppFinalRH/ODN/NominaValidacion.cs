using System;
using System.ComponentModel.DataAnnotations;

namespace ODN
{

    public class NominaValidacion
    {

        [Range(2017, 2019, ErrorMessage = "el ano debe estar entre 2017-2019")]
        public Nullable<int> Anio { get; set; }
        public Nullable<int> MesId { get; set; }
        public string MesT { get; set; }
        public decimal MontoT { get; set; }
        public string Estatus { get; set; }

        public virtual Mes Mes { get; set; }
    }

    [MetadataType(typeof(NominaValidacion))]
    public partial class Nomina
    {

    }
}
