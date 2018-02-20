namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModeOfPaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModeOfPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModeOfPayments");
        }
    }
}
