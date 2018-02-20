namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrandTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BrandTypes VALUES('Imported')");
            Sql("INSERT INTO BrandTypes VALUES('Local')");
        }
        
        public override void Down()
        {
        }
    }
}
