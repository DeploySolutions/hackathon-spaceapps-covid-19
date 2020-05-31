using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DeploySolutions.Covid19Admin.Authorization.Roles;
using DeploySolutions.Covid19Admin.Authorization.Users;
using DeploySolutions.Covid19Admin.MultiTenancy;
using Abp.Localization;
using DeploySolutions.Covid19Admin.Covid19;

namespace DeploySolutions.Covid19Admin.EntityFrameworkCore
{
    public class Covid19AdminDbContext : AbpZeroDbContext<Tenant, Role, User, Covid19AdminDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CovidCase> CovidCases { get; set; }
        public DbSet<EnvironmentFactor> EnvironmentFactors { get; set; }

        public Covid19AdminDbContext(DbContextOptions<Covid19AdminDbContext> options)
            : base(options)
        {
        }

        // add these lines to override max length of property
        // we should set max length smaller than the PostgreSQL allowed size (10485760)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
    }
}
