using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
