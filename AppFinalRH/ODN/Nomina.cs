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
    
    public partial class Nomina
    {
        public int Id { get; set; }
        public Nullable<int> Anio { get; set; }
        public Nullable<int> MesId { get; set; }
        public string MesT { get; set; }
        public decimal MontoT { get; set; }
        public string Estatus { get; set; }
    
        public virtual Mes Mes { get; set; }
    }
}
