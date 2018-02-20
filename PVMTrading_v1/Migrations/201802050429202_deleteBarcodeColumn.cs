namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBarcodeColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Barcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Barcode", c => c.Int(nullable: false));
        }
    }
}
