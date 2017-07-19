namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8073d2a2-f304-40f4-869b-b145e0f4745b', N'guest@test.com', 0, N'AObtUP23bO8p23czX0NplKcBApmlR6GJRSjZMaSmshg/v8i3LrXQCCA2CcxXwFy++A==', N'3ca79064-7d37-4b14-a7e9-1c2ec356fe78', NULL, 0, 0, NULL, 1, 0, N'guest@test.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afb1f3dd-abf7-4806-a455-1fbb0792d071', N'admin@test.com', 0, N'AKP/I5KY2wYXrFDBoQWNCKzOQzoCh7NBFMGoBNwvs33SuzdmhijysHMbDkyg7K7t9w==', N'231e6af1-578a-430e-9d0f-e50413eaa2f5', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e99b6fd5-744e-497a-acce-013c06c16012', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afb1f3dd-abf7-4806-a455-1fbb0792d071', N'e99b6fd5-744e-497a-acce-013c06c16012')
");
        }

        public override void Down()
        {
        }
    }
}
