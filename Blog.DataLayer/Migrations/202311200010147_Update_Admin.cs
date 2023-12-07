namespace Blog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Admin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminPasswordKey", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPasswordKey", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.Binary(nullable: false));
        }
    }
}
