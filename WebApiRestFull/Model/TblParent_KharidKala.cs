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
    using System.Collections.Generic;
    
    public partial class TblParent_KharidKala
    {
        public TblParent_KharidKala()
        {
            this.TblChild_KharidKala = new HashSet<TblChild_KharidKala>();
        }
    
        public long KharidKalaParent_ID { get; set; }
        public Nullable<long> KharidKalaParent_Tafzili { get; set; }
        public Nullable<System.DateTime> KharidKalaParent_Date { get; set; }
        public string KharidKalaParent_Tozih { get; set; }
        public Nullable<long> KharidKalaParent_JameMablaghPaye { get; set; }
        public Nullable<long> KharidKalaParent_JameMaliyat { get; set; }
        public Nullable<long> KharidKalaParent_JameTakhfif { get; set; }
        public Nullable<long> KharidKalaParent_JameMablaghPasTakhfif { get; set; }
        public Nullable<long> KharidKalaParent_JameKol { get; set; }
        public Nullable<long> KharidKalaParent_JameService { get; set; }
        public Nullable<long> KharidKalaParent_UserId { get; set; }
        public string KharidKalaParent_SerialSanad { get; set; }
    
        public virtual ICollection<TblChild_KharidKala> TblChild_KharidKala { get; set; }
    }
}