namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCostumerColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "RegisteredDateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "RegisteredDateCreated", c => c.DateTime(nullable: false));
        }
    }
}
