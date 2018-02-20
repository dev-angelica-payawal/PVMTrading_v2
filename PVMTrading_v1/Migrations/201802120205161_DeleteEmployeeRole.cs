namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployeeRole : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EmployeeRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
