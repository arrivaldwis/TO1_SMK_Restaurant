//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TO1_SMK_Restaurant
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public string employeeId { get; set; }
        public System.DateTime DOB { get; set; }
        public string employeeName { get; set; }
        public int roleId { get; set; }
        public int phoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
