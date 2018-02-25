namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMissingMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProductImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductImage", c => c.String());
        }
    }
}
