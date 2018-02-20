namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashTransactionAndCashTransactionItemTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashTransactionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashTransactionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductPriceId = c.Int(nullable: false),
                        DiscountedAmount = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashTransactions", t => t.CashTransactionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.ProductPrices", t => t.ProductPriceId, cascadeDelete: false)
                .Index(t => t.CashTransactionId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductPriceId);
            
            CreateTable(
                "dbo.CashTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalDiscountedAmount = c.Double(nullable: false),
                        OriginalTotalAmount = c.Double(nullable: false),
                        CashTransactionDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        IsVoid = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactionItems", "ProductPriceId", "dbo.ProductPrices");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropForeignKey("dbo.CashTransactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CashTransactions", new[] { "CustomerId" });
            DropIndex("dbo.CashTransactionItems", new[] { "ProductPriceId" });
            DropIndex("dbo.CashTransactionItems", new[] { "ProductId" });
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropTable("dbo.CashTransactions");
            DropTable("dbo.CashTransactionItems");
        }
    }
}
