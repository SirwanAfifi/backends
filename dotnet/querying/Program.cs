using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using querying.Data;
using querying.Models;

namespace querying
{
    class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<MyDbContext>();

            var query = new Query(dbContext);

            var stopWatch = Stopwatch.StartNew();

            query.FetchData();
            
            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed);

            // BulkImport(dbContext, faker);
        }

        private static void BulkImport(MyDbContext dbContext, Faker faker)
        {
            foreach (var item in dbContext.EntityAs.ToList())
            {
                foreach (var itemB in dbContext.EntityBs.ToList())
                {
                    foreach (var itemC in Enumerable.Range(1, 100))
                    {
                        dbContext.EntityCs.Add(new EntityC
                        {
                            Name = faker.Lorem.Paragraph(1),
                            EntityBId = itemB.Id
                        });
                    }
                }
            }

            dbContext.SaveChanges();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
            
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            services.AddSingleton<IConfigurationRoot>(Configuration);
        }
    }
}
