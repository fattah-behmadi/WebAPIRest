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
    
    public partial class tblLogin
    {
        public tblLogin()
        {
            this.tblSandoghs = new HashSet<tblSandogh>();
        }
    
        public int Login_ID { get; set; }
        public string Login_UserName { get; set; }
        public string Login_Password { get; set; }
        public string Login_Name { get; set; }
        public string Login_Mobile { get; set; }
        public byte[] Login_Pic { get; set; }
        public Nullable<int> Login_RoleID { get; set; }
        public Nullable<bool> Login_Active { get; set; }
        public Nullable<bool> Login_SetUser { get; set; }
        public string Login_Mail { get; set; }
        public Nullable<bool> Login_IsAdmin { get; set; }
    
        public virtual ICollection<tblSandogh> tblSandoghs { get; set; }
    }
}
