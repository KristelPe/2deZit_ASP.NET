using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcCompanies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCompanyContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcCompanyContext>>()))
            {
                // Look for any companies.
                if (context.Company.Any())
                {
                    return;   // DB has been seeded
                }

                context.Company.AddRange(
                    new Company
                     {
                        CompanyID = 1,
                        Name = "The Walt Disney Company",
                        Adres = "500 South Buena Vista Street, Burbank, California, United States"
                     },

                    new Company
                     {
                         CompanyID = 2,
                         Name = "SM Entertainment",
                         Adres = "Seoul, South Korea"
                     },

                    new Company
                     {
                        CompanyID = 3,
                        Name = "Studio Ghibli",
                        Adres = "Koganei, Tokyo, Japan",
                     },

                    new Company
                     {
                        CompanyID = 4,
                        Name = "BuzzFeed",
                        Adres = "New York City, United States"
                     },

                    new Company
                     {
                        CompanyID = 5,
                        Name = "Apple Inc.",
                        Adres = "1 Apple Park Way, Cupertino, California, United States",
                     }
                );

                context.Department.AddRange(
                    new Department
                    {
                        CompanyID = 1,
                        DepartmentID = 11,
                        Name = "Production"
                    },

                    new Department
                    {
                        CompanyID = 1,
                        DepartmentID = 12,
                        Name = "Marketing"
                    },

                    new Department
                    {
                        CompanyID = 2,
                        DepartmentID = 21,
                        Name = "Artists and repertoire"
                    },

                    new Department
                    {
                        CompanyID = 2,
                        DepartmentID = 22,
                        Name = "Legal"
                    },

                    new Department
                    {
                        CompanyID = 3,
                        DepartmentID = 31,
                        Name = "Production"
                    },

                    new Department
                    {
                        CompanyID = 5,
                        DepartmentID = 51,
                        Name = "Legal"
                    },

                    new Department
                    {
                        CompanyID = 5,
                        DepartmentID = 52,
                        Name = "Research and development"
                    },

                    new Department
                    {
                        CompanyID = 5,
                        DepartmentID = 53,
                        Name = "Human resources"
                    }
                );

                context.Employee.AddRange(
                    new Employee
                    {
                        DepartmentID = 11,
                        LastName = "Lasseter",
                        FirstName = "John",
                        Gender = true,
                        Birthdate = DateTime.Parse("1957-1-12"),
                        Occupation = EOccupation.Chief
                    },

                    new Employee
                    {
                        DepartmentID = 11,
                        LastName = "Wise",
                        FirstName = "Kirk",
                        Gender = true,
                        Birthdate = DateTime.Parse("1963-8-24"),
                        Occupation = EOccupation.Animator
                    },

                    new Employee
                    {
                        DepartmentID = 11,
                        LastName = "Trousdale",
                        FirstName = "Gary",
                        Gender = true,
                        Birthdate = DateTime.Parse("1960-6-8"),
                        Occupation = EOccupation.Director
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Choi",
                        FirstName = "Jin-Ri (Sulli)",
                        Gender = false,
                        Birthdate = DateTime.Parse("1994-3-29"),
                        Occupation = EOccupation.Model
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Liu",
                        FirstName = "Amber Joshphine",
                        Gender = false,
                        Birthdate = DateTime.Parse("1992-9-18"),
                        Occupation = EOccupation.Rapper
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Kim",
                        FirstName = "Tae-yeon",
                        Gender = false,
                        Birthdate = DateTime.Parse("1989-3-9"),
                        Occupation = EOccupation.Singer
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Kim",
                        FirstName = "Ryeo-wook",
                        Gender = true,
                        Birthdate = DateTime.Parse("1987-6-21"),
                        Occupation = EOccupation.Actor
                    },

                    new Employee
                    {
                        DepartmentID = 22,
                        LastName = "Liu",
                        FirstName = "June",
                        Gender = false,
                        Birthdate = DateTime.Parse("1990-2-27"),
                        Occupation = EOccupation.Lawyer
                    },

                    new Employee
                    {
                        DepartmentID = 22,
                        LastName = "Wu",
                        FirstName = "Carter",
                        Gender = true,
                        Birthdate = DateTime.Parse("1986-7-12"),
                        Occupation = EOccupation.Lawyer
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Miyazaki",
                        FirstName = "Hayao",
                        Gender = true,
                        Birthdate = DateTime.Parse("1941-5-1"),
                        Occupation = EOccupation.Author
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Takahata",
                        FirstName = "Isao",
                        Gender = true,
                        Birthdate = DateTime.Parse("1935-10-29"),
                        Occupation = EOccupation.Director
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Hisaishi",
                        FirstName = "Joe",
                        Gender = true,
                        Birthdate = DateTime.Parse("1950-6-12"),
                        Occupation = EOccupation.Composer
                    },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Elric",
                        FirstName = "Edward",
                        Gender= true,
                        Birthdate = DateTime.Parse("1983-4-30"),
                        Occupation = EOccupation.Engineer
                     },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Villetta",
                        FirstName = "Lloyd",
                        Gender = true,
                        Birthdate = DateTime.Parse("1979-2-12"),
                        Occupation = EOccupation.Developer
                    },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Evergarden",
                        FirstName = "Violet",
                        Gender = false,
                        Birthdate = DateTime.Parse("1993-6-11"),
                        Occupation = EOccupation.Developer
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
