﻿using Exercise.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
