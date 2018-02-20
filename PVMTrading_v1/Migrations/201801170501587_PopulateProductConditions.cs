namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateProductConditions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductConditions VALUES('New')");
            Sql("INSERT INTO ProductConditions VALUES('Second Hand')");
            Sql("INSERT INTO ProductConditions VALUES('Slightly Used')");
        }

        public override void Down()
        {
        }
    }
}
