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
    
    public partial class tblChildeSanad
    {
        public long ID_Child_Sanad { get; set; }
        public Nullable<long> Serial_Sanad { get; set; }
        public Nullable<int> AccountsID { get; set; }
        public Nullable<int> Tafzili_ID { get; set; }
        public Nullable<int> Moein_ID { get; set; }
        public string Sharh_Child_Sanad { get; set; }
        public Nullable<decimal> ID_Amaliyat { get; set; }
        public Nullable<int> ID_TypeAmaliyat { get; set; }
        public Nullable<long> Bedehkar { get; set; }
        public Nullable<long> Bestankar { get; set; }
    
        public virtual tblParentSanad tblParentSanad { get; set; }
        public virtual tblTafzili tblTafzili { get; set; }
    }
}
