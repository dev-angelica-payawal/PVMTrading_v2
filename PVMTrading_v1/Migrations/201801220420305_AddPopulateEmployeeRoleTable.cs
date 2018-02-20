namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateEmployeeRoleTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeRoles VALUES('Administrator')");
            Sql("INSERT INTO EmployeeRoles VALUES('Sales')");
            Sql("INSERT INTO EmployeeRoles VALUES('Clerk')");
            Sql("INSERT INTO EmployeeRoles VALUES('Cashier')");
            Sql("INSERT INTO EmployeeRoles VALUES('Supervisor')");
            Sql("INSERT INTO EmployeeRoles VALUES('OfficerInCharge')");
        }
        
        public override void Down()
        {
        }
    }
}
