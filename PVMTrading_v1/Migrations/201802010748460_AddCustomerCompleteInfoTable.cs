namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerCompleteInfoTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus");
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CivilStatusId" });
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            CreateTable(
                "dbo.CustomerCompleInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Telephone = c.Int(),
                        CustomerTypeId = c.Int(nullable: false),
                        Email = c.String(maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        CivilStatusId = c.Int(nullable: false),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 255),
                        Nationality = c.String(nullable: false, maxLength: 255),
                        TaxIdentificationNumber = c.Int(),
                        LotHouseNumberAndStreet = c.String(nullable: false, maxLength: 255),
                        Barangay = c.String(nullable: false, maxLength: 255),
                        CityMunicipality = c.String(nullable: false, maxLength: 255),
                        Province = c.String(nullable: false, maxLength: 255),
                        Country = c.String(nullable: false, maxLength: 255),
                        ZipCode = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CivilStatus", t => t.CivilStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerTypes", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTypeId)
                .Index(t => t.CivilStatusId);
            
            DropColumn("dbo.Customers", "Telephone");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Birthdate");
            DropColumn("dbo.Customers", "CivilStatusId");
            DropColumn("dbo.Customers", "PlaceOfBirth");
            DropColumn("dbo.Customers", "Nationality");
            DropColumn("dbo.Customers", "TaxIdentificationNumber");
            DropColumn("dbo.Customers", "CustomerTypeId");
            DropColumn("dbo.Customers", "LotHouseNumberAndStreet");
            DropColumn("dbo.Customers", "Barangay");
            DropColumn("dbo.Customers", "CityMunicipality");
            DropColumn("dbo.Customers", "Province");
            DropColumn("dbo.Customers", "Country");
            DropColumn("dbo.Customers", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ZipCode", c => c.Int());
            AddColumn("dbo.Customers", "Country", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Province", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "CityMunicipality", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Barangay", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "LotHouseNumberAndStreet", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "TaxIdentificationNumber", c => c.Int());
            AddColumn("dbo.Customers", "Nationality", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "PlaceOfBirth", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "CivilStatusId", c => c.Int());
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AddColumn("dbo.Customers", "Email", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Telephone", c => c.Int());
            DropForeignKey("dbo.CustomerCompleInfoes", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.CustomerCompleInfoes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCompleInfoes", "CivilStatusId", "dbo.CivilStatus");
            DropIndex("dbo.CustomerCompleInfoes", new[] { "CivilStatusId" });
            DropIndex("dbo.CustomerCompleInfoes", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerCompleInfoes", new[] { "CustomerId" });
            DropTable("dbo.CustomerCompleInfoes");
            CreateIndex("dbo.Customers", "CustomerTypeId");
            CreateIndex("dbo.Customers", "CivilStatusId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus", "Id");
        }
    }
}
