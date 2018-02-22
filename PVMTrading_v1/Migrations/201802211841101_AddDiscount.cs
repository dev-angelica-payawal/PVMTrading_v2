namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropPrimaryKey("dbo.CashTransactions");
            AddColumn("dbo.CashTransactionItems", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.TempCarts", "Discount", c => c.Double(nullable: false));
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CashTransactions", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropPrimaryKey("dbo.CashTransactions");
            AlterColumn("dbo.CashTransactions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            DropColumn("dbo.TempCarts", "Discount");
            DropColumn("dbo.CashTransactionItems", "Discount");
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id", cascadeDelete: true);
        }
    }
}
