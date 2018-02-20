namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            /*Password ZAQxsw!2    */

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'86276135-52dc-4695-9d60-510f01df3d3b', N'admin@pvm.com', 0, N'AGIx/FKbq62y3gmG8PcnsGxAkFAQ/K63TCQP4GZNdDmmFEOnZS41Lb7ZZxgLapxPow==', N'd8f52d53-a492-4d11-bada-fe3e400720dc', NULL, 0, 0, NULL, 1, 0, N'admin@pvm.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e60fee34-69fa-4e71-b278-981fabdc7da1', N'angel@gmail.com', 0, N'AII8W0XBU0kx0d8Mz0GGWg+Uf/zg7tQgfaCdX/NCf1oZpIIduWfF84majcWwSXKdPg==', N'5b811cc8-ec73-4827-837d-f6f1e5da29a3', NULL, 0, 0, NULL, 1, 0, N'angel@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed75b36e-8488-4e10-a266-d2408e0ed242', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'86276135-52dc-4695-9d60-510f01df3d3b', N'ed75b36e-8488-4e10-a266-d2408e0ed242')

");
        }
        
        public override void Down()
        {
        }
    }
}
