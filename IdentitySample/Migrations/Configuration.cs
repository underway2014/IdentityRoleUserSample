namespace IdentitySample.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdentitySample.Models.ApplicationDbContext";
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var guid = Guid.NewGuid().ToString();
            //var guid1 = Guid.NewGuid().ToString();

            //context.Categories.AddOrUpdate(
            //    new Category { Id = guid, Name = "美食",Description = "好吃的哦",CreateTime = DateTime.Now}
            //    );
            //context.Categories.AddOrUpdate(
            //    new Category { Id = guid1, Name = "娱乐", Description = "", CreateTime = DateTime.Now }
            //    );

            //context.Products.AddOrUpdate(
            //  new Product { Id = Guid.NewGuid().ToString(), Name = "mobile", Price = "22", CategoryId = guid }
            //);

            //context.Products.AddOrUpdate(
            //  new Product { Id = Guid.NewGuid().ToString(), Name = "fans", Price = "222", CategoryId = guid }
            //);

            //context.SaveChanges();
        }
    }
}
