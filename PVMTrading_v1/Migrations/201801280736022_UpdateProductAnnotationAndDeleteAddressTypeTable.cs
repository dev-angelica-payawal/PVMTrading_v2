namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductAnnotationAndDeleteAddressTypeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            AddColumn("dbo.Products", "WarrantyId", c => c.Int());
            AlterColumn("dbo.ProductInclusions", "Quantity", c => c.Int());
            AlterColumn("dbo.ProductPrices", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.ProductPrices", "SellingPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int());
            AlterColumn("dbo.Products", "Model", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "OriginalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Barcode", c => c.Int());
            AlterColumn("dbo.Products", "BrandId", c => c.Int());
            CreateIndex("dbo.ProductInclusions", "ProductId");
            CreateIndex("dbo.Products", "WarrantyId");
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.ProductPrices", "ProductId");
            AddForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties", "Id");
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id");
         //   DropTable("dbo.AddressTypes");
        }
        
        public override void Down()
        {
           /* CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);*/
            
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "WarrantyId" });
            DropIndex("dbo.ProductInclusions", new[] { "ProductId" });
            AlterColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Barcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Model", c => c.String());
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductPrices", "SellingPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductPrices", "UnitPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductInclusions", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "WarrantyId");
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
