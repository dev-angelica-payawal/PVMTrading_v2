namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductPriceId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Id", "dbo.ProductPrices");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Id" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.ProductPrices", "ProductId");
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.Products", "Id");
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Id", "dbo.ProductPrices", "Id");
        }
    }
}
