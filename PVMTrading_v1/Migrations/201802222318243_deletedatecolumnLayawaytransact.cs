namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedatecolumnLayawaytransact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LayAwayTransactions", "TransactionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LayAwayTransactions", "TransactionDate", c => c.DateTime(nullable: false));
        }
    }
}
