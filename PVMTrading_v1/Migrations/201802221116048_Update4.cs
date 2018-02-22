namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransaction_Id" });
            DropColumn("dbo.CashTransactionItems", "CashTransactionId");
            RenameColumn(table: "dbo.CashTransactionItems", name: "CashTransaction_Id", newName: "CashTransactionId");
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            DropColumn("dbo.CashTransactionItems", "Discount");
            DropColumn("dbo.TempCarts", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TempCarts", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.CashTransactionItems", "Discount", c => c.Double(nullable: false));
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CashTransactionItems", name: "CashTransactionId", newName: "CashTransaction_Id");
            AddColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.CashTransactionItems", "CashTransaction_Id");
        }
    }
}
