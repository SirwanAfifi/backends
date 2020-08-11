using System.Collections.Generic;
using querying.Models;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace querying.Data
{
    public class Query
    {
        private readonly MyDbContext _dbContext;

        public Query(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<EntityC> FetchData()
        {
            return _dbContext.EntityCs
                .Where(x => x.EntityB.EntityA.Name == "Sirwan")
                .AsNoTracking().ToList();
        }
    }
}