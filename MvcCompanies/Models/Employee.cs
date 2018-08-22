using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCompanies.Models
{
    public enum EOccupation {
        Chief, Animator, Singer, Developer, Actor, Producer, Lawyer, Director, Model, Rapper, Author, Composer, Engineer, 
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Birthdate { get; set; }
        public EOccupation? Occupation { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}
