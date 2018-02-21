namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntTOstring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropPrimaryKey("dbo.CashTransactions");
            AddColumn("dbo.CashTransactionItems", "CashTransaction_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.CashTransactions", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransaction_Id");
            AddForeignKey("dbo.CashTransactionItems", "CashTransaction_Id", "dbo.CashTransactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransaction_Id", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransaction_Id" });
            DropPrimaryKey("dbo.CashTransactions");
            AlterColumn("dbo.CashTransactions", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.CashTransactionItems", "CashTransaction_Id");
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id", cascadeDelete: true);
        }
    }
}
