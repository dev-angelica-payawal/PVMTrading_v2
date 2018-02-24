namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrToDuePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanDuePayments", "OR", c => c.Int(nullable: false));
            DropColumn("dbo.LoanDuePayments", "Remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanDuePayments", "Remarks", c => c.String());
            DropColumn("dbo.LoanDuePayments", "OR");
        }
    }
}
