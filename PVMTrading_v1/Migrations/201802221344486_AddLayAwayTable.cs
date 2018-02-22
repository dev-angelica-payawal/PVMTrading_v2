namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLayAwayTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LayAwayTransactions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        TotalPaidAmount = c.Double(nullable: false),
                        RemainingBalance = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        IsVoid = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LayAwayTransactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.LayAwayTransactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.LayAwayTransactions", new[] { "ProductId" });
            DropIndex("dbo.LayAwayTransactions", new[] { "CustomerId" });
            DropTable("dbo.LayAwayTransactions");
        }
    }
}
