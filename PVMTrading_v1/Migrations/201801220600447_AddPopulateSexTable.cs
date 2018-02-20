namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateSexTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sexes VALUES('Male')");
            Sql("INSERT INTO Sexes VALUES('Female')");
        }
        
        public override void Down()
        {
        }
    }
}
