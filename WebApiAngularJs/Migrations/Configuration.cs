namespace WebApiAngularJs.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiAngularJs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiAngularJs.Models.BookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApiAngularJs.Models.BookDbContext context)
        {
            context.Books.AddOrUpdate(x => x.Name,
                new Book
                {
                    Name = "Test 1",
                    Price = 2.1M,
                    IsActive = true
                });
        }
    }
}
