namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeDataTypeForOrigiranPriceColumnInProductTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "OriginalPrice", c => c.Double(nullable: false));
        }
    }
}
