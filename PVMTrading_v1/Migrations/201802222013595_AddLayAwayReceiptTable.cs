namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLayAwayReceiptTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LayAwayTransactionReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LayAwayTransactionId = c.String(nullable: false, maxLength: 128),
                        DateTransaction = c.DateTime(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        OR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LayAwayTransactions", t => t.LayAwayTransactionId, cascadeDelete: true)
                .Index(t => t.LayAwayTransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LayAwayTransactionReceipts", "LayAwayTransactionId", "dbo.LayAwayTransactions");
            DropIndex("dbo.LayAwayTransactionReceipts", new[] { "LayAwayTransactionId" });
            DropTable("dbo.LayAwayTransactionReceipts");
        }
    }
}
