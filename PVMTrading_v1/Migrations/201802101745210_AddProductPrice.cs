namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductPrice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
             
            CreateIndex("dbo.Products", "Id");
            AddForeignKey("dbo.Products", "Id", "dbo.ProductPrices", "Id");
            AddForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Id", "dbo.ProductPrices");
            DropIndex("dbo.Products", new[] { "Id" });
            
            
            CreateIndex("dbo.ProductPrices", "ProductId");
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
