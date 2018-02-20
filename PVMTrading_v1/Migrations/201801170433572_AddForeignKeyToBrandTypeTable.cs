namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToBrandTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Brands", "BrandTypeId");
            AddForeignKey("dbo.Brands", "BrandTypeId", "dbo.BrandTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brands", "BrandTypeId", "dbo.BrandTypes");
            DropIndex("dbo.Brands", new[] { "BrandTypeId" });
            DropTable("dbo.BrandTypes");
        }
    }
}
