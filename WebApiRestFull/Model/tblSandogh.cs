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
    
    public partial class tblSandogh
    {
        public int ID_Sandogh { get; set; }
        public string Onvan { get; set; }
        public Nullable<int> Tafzili_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<long> MovjodiAvalDovre { get; set; }
        public string Exp { get; set; }
    
        public virtual tblLogin tblLogin { get; set; }
        public virtual tblTafzili tblTafzili { get; set; }
    }
}
