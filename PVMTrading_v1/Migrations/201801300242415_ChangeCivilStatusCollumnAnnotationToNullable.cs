namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCivilStatusCollumnAnnotationToNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus");
            DropIndex("dbo.Customers", new[] { "CivilStatusId" });
            AlterColumn("dbo.Customers", "CivilStatusId", c => c.Int());
            CreateIndex("dbo.Customers", "CivilStatusId");
            AddForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus");
            DropIndex("dbo.Customers", new[] { "CivilStatusId" });
            AlterColumn("dbo.Customers", "CivilStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CivilStatusId");
            AddForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus", "Id", cascadeDelete: true);
        }
    }
}
