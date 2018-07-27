using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCompanies.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Company Company { get; set; }
    }
}
