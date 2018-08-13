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
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1957-1-12"),
                        Occupation = "Film chief"
                    },

                    new Employee
                    {
                        DepartmentID = 11,
                        LastName = "Wise",
                        FirstName = "Kirk",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1963-8-24"),
                        Occupation = "Animator"
                    },

                    new Employee
                    {
                        DepartmentID = 11,
                        LastName = "Trousdale",
                        FirstName = "Gary",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1960-6-8"),
                        Occupation = "Director"
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Choi",
                        FirstName = "Jin-Ri (Sulli)",
                        Gender = EGender.f,
                        Birthdate = DateTime.Parse("1994-3-29"),
                        Occupation = "Actress - model"
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Liu",
                        FirstName = "Amber Joshphine",
                        Gender = EGender.f,
                        Birthdate = DateTime.Parse("1992-9-18"),
                        Occupation = "Rapper - songwriter - composer"
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Kim",
                        FirstName = "Tae-yeon",
                        Gender = EGender.f,
                        Birthdate = DateTime.Parse("1989-3-9"),
                        Occupation = "Singer"
                    },

                    new Employee
                    {
                        DepartmentID = 21,
                        LastName = "Kim",
                        FirstName = "Ryeo-wook",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1987-6-21"),
                        Occupation = "Singer - songwriter - actor"
                    },

                    new Employee
                    {
                        DepartmentID = 22,
                        LastName = "Liu",
                        FirstName = "June",
                        Gender = EGender.f,
                        Birthdate = DateTime.Parse("1990-2-27"),
                        Occupation = "Lawyer"
                    },

                    new Employee
                    {
                        DepartmentID = 22,
                        LastName = "Wu",
                        FirstName = "Carter",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1986-7-12"),
                        Occupation = "Lawyer"
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Miyazaki",
                        FirstName = "Hayao",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1941-5-1"),
                        Occupation = "Manga artist - author - animator"
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Takahata",
                        FirstName = "Isao",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1935-10-29"),
                        Occupation = "Director"
                    },

                    new Employee
                    {
                        DepartmentID = 31,
                        LastName = "Hisaishi",
                        FirstName = "Joe",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1950-6-12"),
                        Occupation = "Composer - conductor - arranger"
                    },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Elric",
                        FirstName = "Edward",
                        Gender= EGender.m,
                        Birthdate = DateTime.Parse("1983-4-30"),
                        Occupation = "Enigeer"
                     },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Villetta",
                        FirstName = "Lloyd",
                        Gender = EGender.m,
                        Birthdate = DateTime.Parse("1979-2-12"),
                        Occupation = "Technician"
                    },

                    new Employee
                    {
                        DepartmentID = 52,
                        LastName = "Evergarden",
                        FirstName = "Violet",
                        Gender = EGender.f,
                        Birthdate = DateTime.Parse("1993-6-11"),
                        Occupation = "Developer"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
