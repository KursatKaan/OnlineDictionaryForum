namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_HeadingTitle_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headings", "HeadingTitle", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headings", "HeadingTitle", c => c.String(maxLength: 50));
        }
    }
}
