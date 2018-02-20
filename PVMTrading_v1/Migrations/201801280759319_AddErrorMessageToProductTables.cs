namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorMessageToProductTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Model", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "Barcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            AlterColumn("dbo.Products", "BrandId", c => c.Int());
            AlterColumn("dbo.Products", "Barcode", c => c.Int());
            AlterColumn("dbo.Products", "Model", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int());
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id");
        }
    }
}
