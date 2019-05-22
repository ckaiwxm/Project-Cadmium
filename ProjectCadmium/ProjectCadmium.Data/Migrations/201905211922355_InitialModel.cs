namespace ProjectCadmium.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        PricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastUsedTimestamp = c.DateTime(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuoteVersions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UniqueID = c.String(nullable: false, maxLength: 50),
                        Version = c.Guid(nullable: false),
                        IsBillable = c.Boolean(nullable: false),
                        QuoteID = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        ProjectID = c.Guid(nullable: false),
                        ClientID = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Quotes", t => t.QuoteID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.QuoteID)
                .Index(t => t.ProjectID)
                .Index(t => t.ClientID)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublishVersion = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastLoginTimestamp = c.DateTime(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserVersions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Version = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        LastUsedTimestamp = c.DateTime(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublishVersion = c.Guid(nullable: false),
                        NewPricePerHour = c.Decimal(precision: 18, scale: 2),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        QuoteID = c.Guid(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotes", t => t.QuoteID, cascadeDelete: true)
                .Index(t => t.QuoteID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Hours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuoteVersionID = c.Guid(nullable: false),
                        Nth = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuoteVersions", t => t.QuoteVersionID, cascadeDelete: true)
                .Index(t => t.QuoteVersionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuoteVersions", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Tasks", "QuoteVersionID", "dbo.QuoteVersions");
            DropForeignKey("dbo.QuoteVersions", "QuoteID", "dbo.Quotes");
            DropForeignKey("dbo.Payments", "QuoteID", "dbo.Quotes");
            DropForeignKey("dbo.QuoteVersions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.UserVersions", "UserID", "dbo.Users");
            DropForeignKey("dbo.QuoteVersions", "CreatedById", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "QuoteVersionID" });
            DropIndex("dbo.Payments", new[] { "QuoteID" });
            DropIndex("dbo.UserVersions", new[] { "UserID" });
            DropIndex("dbo.QuoteVersions", new[] { "CreatedById" });
            DropIndex("dbo.QuoteVersions", new[] { "ClientID" });
            DropIndex("dbo.QuoteVersions", new[] { "ProjectID" });
            DropIndex("dbo.QuoteVersions", new[] { "QuoteID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Payments");
            DropTable("dbo.Quotes");
            DropTable("dbo.Projects");
            DropTable("dbo.UserVersions");
            DropTable("dbo.Users");
            DropTable("dbo.QuoteVersions");
            DropTable("dbo.Clients");
        }
    }
}
