using EmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeDetails.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {


        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> BackUpEmployee { get; set; }
    }
}
