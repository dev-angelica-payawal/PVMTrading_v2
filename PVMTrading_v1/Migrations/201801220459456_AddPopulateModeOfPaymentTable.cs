namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateModeOfPaymentTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ModeOfPayments VALUES('Daily')");
            Sql("INSERT INTO ModeOfPayments VALUES('Weekly')");
            Sql("INSERT INTO ModeOfPayments VALUES('Semimonthly')");
            Sql("INSERT INTO ModeOfPayments VALUES('Monthly')");
        }
        
        public override void Down()
        {
        }
    }
}
