namespace ProjectCadmium.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTaskRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "QuoteVersionID", "dbo.QuoteVersions");
            DropIndex("dbo.Tasks", new[] { "QuoteVersionID" });
            AddColumn("dbo.Tasks", "QuoteID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tasks", "QuoteID");
            AddForeignKey("dbo.Tasks", "QuoteID", "dbo.Quotes", "Id", cascadeDelete: true);
            DropColumn("dbo.Tasks", "QuoteVersionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "QuoteVersionID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Tasks", "QuoteID", "dbo.Quotes");
            DropIndex("dbo.Tasks", new[] { "QuoteID" });
            DropColumn("dbo.Tasks", "QuoteID");
            CreateIndex("dbo.Tasks", "QuoteVersionID");
            AddForeignKey("dbo.Tasks", "QuoteVersionID", "dbo.QuoteVersions", "Id", cascadeDelete: true);
        }
    }
}
