namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageColumnToProductTableAndCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.CustomerCompleInfoes", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerCompleInfoes", "Image");
            DropColumn("dbo.Products", "Image");
        }
    }
}
