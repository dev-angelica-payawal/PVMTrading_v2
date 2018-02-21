namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary());
        }
    }
}
