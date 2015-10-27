namespace IdentitySample.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
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

            var award = new Award();
            award.Name = "电影票";
            award.Description = "test";
            award.Id = Guid.NewGuid().ToString();

            var award1 = new Award();
            award1.Name = "打折卡";
            award1.Description = "test1";
            award1.Id = Guid.NewGuid().ToString();

            var activity = new Activity();
            activity.Name = "抽奖";
            activity.Id = Guid.NewGuid().ToString();

            var activity1 = new Activity();
            activity1.Name = "打折狂购";
            activity1.Id = Guid.NewGuid().ToString();



            award.Activities = new List<Activity>();
            award.Activities.Add(activity);

            award1.Activities = new List<Activity>();
            award1.Activities.Add(activity1);

            activity1.Awards = new List<Award>();
            activity1.Awards.Add(award);
            activity1.Awards.Add(award1);

            context.Awards.Add(award);
            context.Awards.Add(award1);

            context.Activities.Add(activity);
            context.Activities.Add(activity1);


            context.SaveChanges();
        }
    }
}
