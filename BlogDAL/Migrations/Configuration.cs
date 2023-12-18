namespace BlogDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogDAL.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogDAL.BlogDbContext";
        }

        protected override void Seed(BlogDAL.BlogDbContext context)
        {
            var admin = new AdminInfo
            {
                EmailId = "shashant@admin.com",
                Password = "Sha@1234"
            };
            context.AdminInfos.Add(admin);
            // Add additional seeding for other tables if needed

            base.Seed(context);
        }
    }
}
