namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_writer_pass_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "Password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Password", c => c.String(maxLength: 20));
        }
    }
}
