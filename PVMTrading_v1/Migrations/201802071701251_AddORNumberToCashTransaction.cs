namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddORNumberToCashTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashTransactions", "OR", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashTransactions", "OR");
        }
    }
}
