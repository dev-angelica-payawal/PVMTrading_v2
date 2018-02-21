namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            /*Password ZAQxsw!2    
            admin@pvm.com - admin Role
<<<<<<< HEAD
            angel@gmail.com - customer role*/
=======
            customer - customer role*/
>>>>>>> d3f94b727655c11ed325b3331980c46183640e64


            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [BranchId]) VALUES (N'86276135-52dc-4695-9d60-510f01df3d3b', N'admin@pvm.com', 0, N'AGIx/FKbq62y3gmG8PcnsGxAkFAQ/K63TCQP4GZNdDmmFEOnZS41Lb7ZZxgLapxPow==', N'd8f52d53-a492-4d11-bada-fe3e400720dc', NULL, 0, 0, NULL, 1, 0, N'admin@pvm.com', 1)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [BranchId]) VALUES (N'e60fee34-69fa-4e71-b278-981fabdc7da1', N'angel@gmail.com', 0, N'AII8W0XBU0kx0d8Mz0GGWg+Uf/zg7tQgfaCdX/NCf1oZpIIduWfF84majcWwSXKdPg==', N'5b811cc8-ec73-4827-837d-f6f1e5da29a3', NULL, 0, 0, NULL, 1, 0, N'customer', 1)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'4f7d3200-4f58-4cb3-843d-ba2a547b8cb3', N'Customer', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'ed75b36e-8488-4e10-a266-d2408e0ed242', N'Admin', N'ApplicationRole')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'86276135-52dc-4695-9d60-510f01df3d3b', N'ed75b36e-8488-4e10-a266-d2408e0ed242')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e60fee34-69fa-4e71-b278-981fabdc7da1', N'ed75b36e-8488-4e10-a266-d2408e0ed242')

");
        }
        
        public override void Down()
        {
        }
    }
}
