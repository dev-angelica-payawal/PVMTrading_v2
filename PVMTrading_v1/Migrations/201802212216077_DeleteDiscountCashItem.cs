namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDiscountCashItem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CashTransactionItems", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CashTransactionItems", "Discount", c => c.Double(nullable: false));
        }
    }
}
