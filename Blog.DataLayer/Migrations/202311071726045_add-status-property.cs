namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatusproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterStatus");
            DropColumn("dbo.Contents", "ContentStatus");
        }
    }
}
