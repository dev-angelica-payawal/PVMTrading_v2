namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerForeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Loans", "CustomerId");
            AddForeignKey("dbo.Loans", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Loans", new[] { "CustomerId" });
            DropColumn("dbo.Loans", "CustomerId");
        }
    }
}
