namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.CustomerCompleInfoes", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerCompleInfoes", "Image", c => c.Binary(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
        }
    }
}
