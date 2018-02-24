namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanDuePayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanDuePayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanId = c.String(maxLength: 128),
                        DueDateTime = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        PenaltyAmount = c.Double(nullable: false),
                        TotalAmountDue = c.Double(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.LoanId)
                .Index(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDuePayments", "LoanId", "dbo.Loans");
            DropIndex("dbo.LoanDuePayments", new[] { "LoanId" });
            DropTable("dbo.LoanDuePayments");
        }
    }
}
