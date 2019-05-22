namespace ProjectCadmium.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullPublishVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PublishVersion", c => c.Guid());
            AlterColumn("dbo.Quotes", "PublishVersion", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "PublishVersion", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "PublishVersion", c => c.Guid(nullable: false));
        }
    }
}
