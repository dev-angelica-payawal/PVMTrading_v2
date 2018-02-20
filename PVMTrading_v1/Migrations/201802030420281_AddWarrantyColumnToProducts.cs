namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdcut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties");
            DropIndex("dbo.Products", new[] { "WarrantyId" });
            CreateTable(
                "dbo.ProductReturnReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Products", "WarrantyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "WarrantyId");
            AddForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties");
            DropIndex("dbo.Products", new[] { "WarrantyId" });
            AlterColumn("dbo.Products", "WarrantyId", c => c.Int());
            DropTable("dbo.ProductReturnReasons");
            CreateIndex("dbo.Products", "WarrantyId");
            AddForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties", "Id");
        }
    }
}
