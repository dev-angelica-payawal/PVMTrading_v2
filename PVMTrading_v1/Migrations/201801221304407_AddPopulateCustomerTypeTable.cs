namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateCustomerTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerTypes VALUES('New')");
            Sql("INSERT INTO CustomerTypes VALUES('Regular')");
            Sql("INSERT INTO CustomerTypes VALUES('BlackListed')");
        }
        
        public override void Down()
        {
        }
    }
}
