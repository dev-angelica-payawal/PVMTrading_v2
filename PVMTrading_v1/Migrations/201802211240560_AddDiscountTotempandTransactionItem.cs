namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscountTotempandTransactionItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashTransactionItems", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.TempCarts", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TempCarts", "Discount");
            DropColumn("dbo.CashTransactionItems", "Discount");
        }
    }
}
