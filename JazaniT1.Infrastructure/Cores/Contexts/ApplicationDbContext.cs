using JazaniT1.Domain.Admins.Models;
using JazaniT1.Infrastructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JazaniT1.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       }
    }
}