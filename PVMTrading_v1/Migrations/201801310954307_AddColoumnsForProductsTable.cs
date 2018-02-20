namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColoumnsForProductsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Reserved", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "AvailableForSelling", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AvailableForSelling");
            DropColumn("dbo.Products", "Reserved");
        }
    }
}
