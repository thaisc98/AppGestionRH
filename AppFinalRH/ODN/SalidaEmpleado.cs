//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ODN
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalidaEmpleado
    {
        public int Id { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
        public string Tipo { get; set; }
        public string Motivo { get; set; }
        public System.DateTime FechaSalida { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
