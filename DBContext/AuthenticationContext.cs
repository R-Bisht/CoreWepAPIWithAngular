using CoreWepAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreWepAPI.Model
{
    public class AuthenticationContext : IdentityDbContext
    {

        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<District> Districts { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<StudentClass> studentClasses { get; set; }
    }
}
