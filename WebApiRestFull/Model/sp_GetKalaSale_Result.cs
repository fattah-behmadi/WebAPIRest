//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    
    public partial class sp_GetKalaSale_Result
    {
        public long ID_Kala { get; set; }
        public string Name_Kala { get; set; }
        public Nullable<long> Fk_GroupKala { get; set; }
        public Nullable<long> Fk_VahedKalaAsli { get; set; }
        public Nullable<long> GheymatForoshAsli { get; set; }
        public Nullable<int> DarsadTakhfif { get; set; }
        public Nullable<int> DarsadMaliyat { get; set; }
        public Nullable<bool> MoafMaliyat { get; set; }
        public Nullable<int> HadaghalMovjodi { get; set; }
        public Nullable<bool> ControlCount { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Tozihat { get; set; }
        public Nullable<double> MojodiAvalDore { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<long> Fk_Anbar { get; set; }
    }
}
