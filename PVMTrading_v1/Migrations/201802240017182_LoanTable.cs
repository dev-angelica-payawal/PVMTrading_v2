namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Downpayment = c.Double(nullable: false),
                        LoanAmount = c.Double(nullable: false),
                        ModeOfPaymentId = c.Int(nullable: false),
                        Terms = c.Int(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        DuePayment = c.Double(nullable: false),
                        LoanTotalPayment = c.Double(nullable: false),
                        LoanStatusId = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 500),
                        LoanDateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoanStatus", t => t.LoanStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ModeOfPayments", t => t.ModeOfPaymentId, cascadeDelete: true)
                .Index(t => t.ModeOfPaymentId)
                .Index(t => t.LoanStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "ModeOfPaymentId", "dbo.ModeOfPayments");
            DropForeignKey("dbo.Loans", "LoanStatusId", "dbo.LoanStatus");
            DropIndex("dbo.Loans", new[] { "LoanStatusId" });
            DropIndex("dbo.Loans", new[] { "ModeOfPaymentId" });
            DropTable("dbo.Loans");
        }
    }
}
