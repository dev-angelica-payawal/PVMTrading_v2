namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateWarrantyTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Warranties VALUES('No Warranty Available For This Product')");
            Sql("INSERT INTO Warranties VALUES('7 Days')");
            Sql("INSERT INTO Warranties VALUES('1 Month')");
            Sql("INSERT INTO Warranties VALUES('3 Months')");
            Sql("INSERT INTO Warranties VALUES('6 Months')");
            Sql("INSERT INTO Warranties VALUES('1 Year')");
            Sql("INSERT INTO Warranties VALUES('2 Years')");
            Sql("INSERT INTO Warranties VALUES('5 Years')");
        }
        
        public override void Down()
        {
        }
    }
}
