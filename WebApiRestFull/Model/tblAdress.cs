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
    
    public partial class tblAdress
    {
        public int Address_ID { get; set; }
        public Nullable<long> Contact_ID { get; set; }
        public string Adress { get; set; }
    
        public virtual tblContact tblContact { get; set; }
    }
}
