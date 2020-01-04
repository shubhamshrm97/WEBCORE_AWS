using System;
using System.Collections.Generic;

namespace CoreAPP
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public int Age { get; set; }
        public DateTime? Dob { get; set; }

        public Department Department { get; set; }
    }
}
