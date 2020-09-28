using EmployeeAPI.Authentication;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeAPI.Data
{
    public class ApplicationUserDbContext : IdentityDbContext<User>
    {
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options): base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
