using System;
using System.Collections.Generic;

namespace CoreAPP
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string City { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
