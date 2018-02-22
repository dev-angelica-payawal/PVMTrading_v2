namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteDiscountTempCart : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TempCarts", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TempCarts", "Discount", c => c.Double(nullable: false));
        }
    }
}
