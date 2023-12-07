namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writer_level : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Level", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Level");
        }
    }
}
