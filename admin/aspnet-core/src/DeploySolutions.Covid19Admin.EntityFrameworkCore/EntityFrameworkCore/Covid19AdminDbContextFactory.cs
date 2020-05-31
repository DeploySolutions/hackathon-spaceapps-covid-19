using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DeploySolutions.Covid19Admin.Configuration;
using DeploySolutions.Covid19Admin.Web;

namespace DeploySolutions.Covid19Admin.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Covid19AdminDbContextFactory : IDesignTimeDbContextFactory<Covid19AdminDbContext>
    {
        public Covid19AdminDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Covid19AdminDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Covid19AdminDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Covid19AdminConsts.ConnectionStringName));

            return new Covid19AdminDbContext(builder.Options);
        }
    }
}
