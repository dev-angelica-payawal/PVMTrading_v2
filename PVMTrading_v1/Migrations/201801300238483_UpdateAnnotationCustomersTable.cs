namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnnotationCustomersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MiddleName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "NameExtension", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Telephone", c => c.Int());
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Customers", "PlaceOfBirth", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Nationality", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "TaxIdentificationNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TaxIdentificationNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Nationality", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "PlaceOfBirth", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Telephone", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "NameExtension", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "MiddleName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}



