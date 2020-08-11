using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using querying.Models;

namespace querying.Data
{
    public class MyDbContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public MyDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public DbSet<EntityA> EntityAs { get; set; }
        public DbSet<EntityB> EntityBs { get; set; }
        public DbSet<EntityC> EntityCs { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("DataConnection"))
                .EnableSensitiveDataLogging();
            
            // options.ConfigureWarnings(warnings =>
            // {
            //     warnings.Log(CoreEventId.IncludeIgnoredWarning);
            //     warnings.Log(RelationalEventId.QueryClientEvaluationWarning);
            // });
            // options.UseLoggerFactory(GetLoggerFactory());
        }
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder.AddConsole()
                    //.AddFilter(category: DbLoggerCategory.Database.Command.Name, level: LogLevel.Information));
                    .AddFilter(level => true)); // log everything
            return serviceCollection.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
        }
    }
}