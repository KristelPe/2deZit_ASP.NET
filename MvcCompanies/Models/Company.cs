using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCompanies.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
