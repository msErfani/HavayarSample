using Domain.Entities;
using Infrastructure.EF.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.EF
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "31c5ef3f-ac1f-4320-a269-6b76ca7cb469", Name = "Admin", NormalizedName = "admin" },
                new IdentityRole { Id = "7169D087-8B01-4208-A11C-382ADA23F0DF", Name = "User", NormalizedName = "user" }
                );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfig).Assembly);


            base.OnModelCreating(modelBuilder);
        }
    }
}
