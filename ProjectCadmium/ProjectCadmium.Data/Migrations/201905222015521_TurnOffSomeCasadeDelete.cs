namespace ProjectCadmium.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnOffSomeCasadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuoteVersions", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.QuoteVersions", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.QuoteVersions", "ProjectID", "dbo.Projects");
            AddForeignKey("dbo.QuoteVersions", "ClientID", "dbo.Clients", "Id");
            AddForeignKey("dbo.QuoteVersions", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.QuoteVersions", "ProjectID", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuoteVersions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.QuoteVersions", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.QuoteVersions", "ClientID", "dbo.Clients");
            AddForeignKey("dbo.QuoteVersions", "ProjectID", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuoteVersions", "CreatedById", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuoteVersions", "ClientID", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
