namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateBranchesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Branches VALUES('First Branch','Arayat')");
            Sql("INSERT INTO Branches VALUES('Main Branch','Arayat')");
            Sql("INSERT INTO Branches VALUES('Third Branch','Mexico')");
        }

        public override void Down()
        {
        }
    }
}
