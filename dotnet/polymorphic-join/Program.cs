using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using polymorphic_join.Data;
using polymorphic_join.Models;

namespace polymorphic_join
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<MyDbContext>();
            #region MyRegion

            // dbContext.Companies.Add(new Company { Name = "CompanyA" });
            // dbContext.Companies.Add(new Company { Name = "CompanyB" });
            // dbContext.Companies.Add(new Company { Name = "CompanyB" });

            // dbContext.Users.Add(new User { Username = "Sirwan" });
            // dbContext.Users.Add(new User { Username = "Vahid" });
            // dbContext.Users.Add(new User { Username = "Amin" });
            // dbContext.Users.Add(new User { Username = "UserB" });

            // dbContext.Orders.Add(new Order { TargetType = OrderType.Company, TargetId = 1 });
            // dbContext.Orders.Add(new Order { TargetType = OrderType.Company, TargetId = 2 });
            // dbContext.Orders.Add(new Order { TargetType = OrderType.Company, TargetId = 3 });


            // dbContext.Orders.Add(new Order { TargetType = OrderType.User, TargetId = 1 });
            // dbContext.Orders.Add(new Order { TargetType = OrderType.User, TargetId = 2 });
            // dbContext.Orders.Add(new Order { TargetType = OrderType.User, TargetId = 3 });
            // dbContext.Orders.Add(new Order { TargetType = OrderType.User, TargetId = 4 });


            // dbContext.SaveChanges();
            // var orders = dbContext.Orders.Type<Company>().ToList();

            #endregion

            //dbContext.Articles.Add(new Article {Title = "Article 1", Slug = "article_1", Description = "Nodesc"});
            // dbContext.Comments.Add(new Comment { CommentText = "Great", User = "Sirwan", CommentType = CommentType.Article, Id = 1});
            // dbContext.Comments.Add(new Comment { CommentText = "Hey great again", User = "Sirwan", CommentType = CommentType.Article, Id = 1});
            // dbContext.SaveChanges();

            var list = dbContext.Articles.Where(x => x.Id == 1).IncludeComments(dbContext);
            foreach (var item in list)
            {
                foreach (var comment in item.Comments)
                {
                    Console.WriteLine(comment.CommentText);
                }
            }
            // var orders2 = dbContext.Orders.CastType<Order, User>().ToList();
            //
            // foreach (var order in orders2)
            // {
            //     Console.WriteLine(order.TargetType);
            // }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
        }
    }

    public static class Ext
    {
        public static IQueryable<Order> Type<T>(this DbSet<Order> source)
        {
            var type = typeof(T) == typeof(User) ? OrderType.User : OrderType.Company;
            return source.Where(x => x.TargetType == type);
        }

        public static IEnumerable<TEntity> CastType<TEntity, T>(this DbSet<TEntity> source) where TEntity : class
        {
            OrderType type = typeof(T) == typeof(User) ? OrderType.User : OrderType.Company;
            // e =>
            var param = Expression.Parameter(typeof(TEntity), "e");
            // e => e.TargetType    
            var property = Expression.Property(param, "TargetType");
            var value = Expression.Constant(type, typeof(OrderType));
            // e => e.TargetType == type
            var body = Expression.Equal(property, value);
            var predicate = Expression.Lambda<Func<TEntity, bool>>(body, param);

            return source.Where(predicate);
        }

        public static IQueryable<Article> IncludeComments(this IQueryable<Article> query, MyDbContext context)
        {
            return query.Select(x => new Article { Comments = context.Comments.Where(c => c.CommentType == CommentType.Article && c.TypeId == x.Id).ToList()});
        }
    }
}
