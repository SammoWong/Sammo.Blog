namespace Sammo.Blog.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        PageViews = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        BlogId = c.Guid(nullable: false),
                        CatogotyId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .ForeignKey("dbo.Category", t => t.CatogotyId)
                .Index(t => t.BlogId)
                .Index(t => t.CatogotyId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 140),
                        Url = c.String(maxLength: 250),
                        Visits = c.Int(nullable: false),
                        PageViews = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        NickName = c.String(maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 64),
                        Salt = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false, maxLength: 30),
                        Gender = c.Short(),
                        AvatarUrl = c.String(maxLength: 250),
                        IsComfirmed = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        LastLoginTime = c.DateTime(),
                        LastLoginIp = c.String(maxLength: 16),
                        RoleType = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleType)
                .Index(t => t.RoleType);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false, maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Article", t => t.ArticleId)
                .Index(t => t.UserId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(maxLength: 30),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(maxLength: 30),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        BlogId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(maxLength: 30),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleTagRelation",
                c => new
                    {
                        ArticleId = c.Guid(nullable: false),
                        TagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.TagId })
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTagRelation", "TagId", "dbo.Tag");
            DropForeignKey("dbo.ArticleTagRelation", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.Comment", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.Article", "CatogotyId", "dbo.Category");
            DropForeignKey("dbo.Tag", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.User", "RoleType", "dbo.Role");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Blog", "UserId", "dbo.User");
            DropForeignKey("dbo.Article", "BlogId", "dbo.Blog");
            DropIndex("dbo.ArticleTagRelation", new[] { "TagId" });
            DropIndex("dbo.ArticleTagRelation", new[] { "ArticleId" });
            DropIndex("dbo.Tag", new[] { "BlogId" });
            DropIndex("dbo.Comment", new[] { "ArticleId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleType" });
            DropIndex("dbo.Blog", new[] { "UserId" });
            DropIndex("dbo.Article", new[] { "CatogotyId" });
            DropIndex("dbo.Article", new[] { "BlogId" });
            DropTable("dbo.ArticleTagRelation");
            DropTable("dbo.Category");
            DropTable("dbo.Tag");
            DropTable("dbo.Role");
            DropTable("dbo.Comment");
            DropTable("dbo.User");
            DropTable("dbo.Blog");
            DropTable("dbo.Article");
        }
    }
}
