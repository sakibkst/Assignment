﻿using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Designation>? Designations { get; set; }
    }
}
