namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyBranchToUsers : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspNetUsers", "BranchId");
            AddForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches");
            DropIndex("dbo.AspNetUsers", new[] { "BranchId" });
        }
    }
}
