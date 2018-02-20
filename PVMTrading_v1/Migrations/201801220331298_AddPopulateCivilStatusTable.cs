namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateCivilStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CivilStatus VALUES('Single')");
            Sql("INSERT INTO CivilStatus VALUES('Married')");
            Sql("INSERT INTO CivilStatus VALUES('Divorced')");
            Sql("INSERT INTO CivilStatus VALUES('Widowed')");
        }
        
        public override void Down()
        {
        }
    }
}
