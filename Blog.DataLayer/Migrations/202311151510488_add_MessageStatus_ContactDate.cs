namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_MessageStatus_ContactDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
