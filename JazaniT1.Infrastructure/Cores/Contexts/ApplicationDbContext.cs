using JazaniT1.Domain.Admins.Models;
using JazaniT1.Infrastructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        #region "DbSet"
        public DbSet<LevelEducation> LevelEducations { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LevelEducationConfiguration());
            modelBuilder.ApplyConfiguration(new MeasureUnitConfiguration());
        }
    }
}