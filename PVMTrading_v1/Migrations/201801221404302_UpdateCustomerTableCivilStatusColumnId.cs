namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerTableCivilStatusColumnId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "CivilStatusid" });
            CreateIndex("dbo.Customers", "CivilStatusId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "CivilStatusId" });
            CreateIndex("dbo.Customers", "CivilStatusid");
        }
    }
}
