namespace Sammo.Blog.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Sammo.Blog.Repository.EntityFramework.SammoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Sammo.Blog.Repository.EntityFramework.SammoDbContext context)
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
            context.Role.AddOrUpdate(
                r => r.Type,
                new Domain.Entities.Role { Type = "Admin", Name = "系统管理员", Description = "系统管理员", CreatedOn = DateTime.Now, Id = Guid.NewGuid() },
                new Domain.Entities.Role { Type = "User", Name = "用户", Description = "用户", CreatedOn = DateTime.Now, Id = Guid.NewGuid() }
                );
            context.SaveChanges();
        }
    }
}
