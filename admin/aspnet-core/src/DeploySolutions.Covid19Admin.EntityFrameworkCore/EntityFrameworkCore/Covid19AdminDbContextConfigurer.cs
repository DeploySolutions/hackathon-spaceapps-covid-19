using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DeploySolutions.Covid19Admin.EntityFrameworkCore
{
    public static class Covid19AdminDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Covid19AdminDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Covid19AdminDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseNpgsql(connection);
        }
    }
}
