namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNameForLoanToProductPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "ProductPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Loans", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "TotalAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Loans", "ProductPrice");
        }
    }
}
