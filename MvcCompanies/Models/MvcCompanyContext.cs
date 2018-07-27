using System;
using Microsoft.EntityFrameworkCore;

namespace MvcCompanies.Models
{
    public class MvcCompanyContext : DbContext
    {
        public MvcCompanyContext (DbContextOptions<MvcCompanyContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCompanies.Models.Company> Company { get; set; }
        public DbSet<MvcCompanies.Models.Department> Department { get; set; }
        public DbSet<MvcCompanies.Models.Employee> Employee { get; set; }

    }
}
