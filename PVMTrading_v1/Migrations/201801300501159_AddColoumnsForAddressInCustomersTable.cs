namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColoumnsForAddressInCustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LotHouseNumberAndStreet", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Barangay", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "CityMunicipality", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Province", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Country", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "ZipCode", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Customers", "Country");
            DropColumn("dbo.Customers", "Province");
            DropColumn("dbo.Customers", "CityMunicipality");
            DropColumn("dbo.Customers", "Barangay");
            DropColumn("dbo.Customers", "LotHouseNumberAndStreet");
        }
    }
}
