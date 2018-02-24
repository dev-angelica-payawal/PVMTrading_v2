namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Loans", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Loans", "TotalAmount", c => c.Double(nullable: false));
            CreateIndex("dbo.Loans", "ProductId");
            AddForeignKey("dbo.Loans", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "ProductId", "dbo.Products");
            DropIndex("dbo.Loans", new[] { "ProductId" });
            DropColumn("dbo.Loans", "TotalAmount");
            DropColumn("dbo.Loans", "Quantity");
            DropColumn("dbo.Loans", "ProductId");
        }
    }
}
