using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Domain.Models;

namespace SalaryCalculator.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private static bool created = false;
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            if (!created)
            {
                Database.EnsureCreated();
                created = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed sample data
            modelBuilder.Entity<Account>().HasData(
                new {Id = 1, Surname = "Strugala"},
                new {Id = 2, Surname = "Adamczyk"}
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
