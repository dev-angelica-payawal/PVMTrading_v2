namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PvMCarts", "ProductId", "dbo.Products");
            DropIndex("dbo.PvMCarts", new[] { "ProductId" });
            CreateTable(
                "dbo.TempCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            DropTable("dbo.PvMCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PvMCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TempCarts", "ProductId", "dbo.Products");
            DropIndex("dbo.TempCarts", new[] { "ProductId" });
            DropTable("dbo.TempCarts");
            CreateIndex("dbo.PvMCarts", "ProductId");
            AddForeignKey("dbo.PvMCarts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
