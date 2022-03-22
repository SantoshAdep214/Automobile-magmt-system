using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class Employee
    {
        public int Employeeid { get; set; }
        public string Employeename { get; set; }
        public string Employeeaddress { get; set; }
        public long? Employeemobno { get; set; }
        public string Employeeemail { get; set; }
        public string Employeepass { get; set; }
    }
}
