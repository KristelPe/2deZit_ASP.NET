using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCompanies.Models
{
    public enum EGender {
        m, f,
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public EGender Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string Occupation { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}
