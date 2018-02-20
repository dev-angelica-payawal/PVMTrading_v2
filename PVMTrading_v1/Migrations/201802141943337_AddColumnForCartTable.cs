namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnForCartTable : DbMigration
    {
        public override void Up()
        {
           AddColumn("dbo.Cart", "CartId", c => c.String(maxLength: 255));
            AddColumn("dbo.Cart", "ProductId", c => c.Int());
            AddColumn("dbo.Cart", "Count", c => c.Int());
            AddColumn("dbo.Cart", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cart", "Label");
            
        }
    }
}
