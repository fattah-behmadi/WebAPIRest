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
    
    public partial class tblTafzili
    {
        public tblTafzili()
        {
            this.tblSandoghs = new HashSet<tblSandogh>();
            this.tblChildeSanads = new HashSet<tblChildeSanad>();
            this.tblContacts = new HashSet<tblContact>();
        }
    
        public int Tafzili_ID { get; set; }
        public Nullable<int> GroupTafzili_ID { get; set; }
        public string Tafzili_Name { get; set; }
        public Nullable<int> User_ID_Tafzili { get; set; }
        public Nullable<int> TypeAcc_ID { get; set; }
    
        public virtual ICollection<tblSandogh> tblSandoghs { get; set; }
        public virtual ICollection<tblChildeSanad> tblChildeSanads { get; set; }
        public virtual ICollection<tblContact> tblContacts { get; set; }
    }
}
