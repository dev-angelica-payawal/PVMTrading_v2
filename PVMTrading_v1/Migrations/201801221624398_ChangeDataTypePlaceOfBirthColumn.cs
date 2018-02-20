namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypePlaceOfBirthColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PlaceOfBirth", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PlaceOfBirth", c => c.String(nullable: false));
        }
    }
}
