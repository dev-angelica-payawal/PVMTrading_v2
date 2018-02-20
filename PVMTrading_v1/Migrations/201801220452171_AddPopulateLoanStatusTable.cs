namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateLoanStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO LoanStatus VALUES('Pending')");
            Sql("INSERT INTO LoanStatus VALUES('Approved')");
            Sql("INSERT INTO LoanStatus VALUES('Disapproved')");
        }
        
        public override void Down()
        {
        }
    }
}
