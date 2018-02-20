namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToProductCategoriesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String());
        }
    }
}
