namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writer_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "About", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "About");
        }
    }
}
