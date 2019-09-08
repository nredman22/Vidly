namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'394c5830-7343-415c-9a58-5af0fd4886f2', N'admin@vidly.com', 0, N'AMSJR2daeh5YHdbC/bhkwV66x67dly87cQDvpMWk2YJ4sRkEX4IRVEOxS5/WUUl+0w==', N'4641a01c-d050-47b7-87a1-b9ac19419de2', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b017bf5-fe7e-4406-80a6-488b9a7f79a3', N'guest@vidly.com', 0, N'AFZ5rJ+lKxsYPYN+y79DqLaHkpmzWnf0oT6UnBV96uy+diOF2TzOYIuTfZN0u6Em9g==', N'31dd38c4-308f-4d63-a06e-b47824fb41d5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e5603f45-7bff-4174-8ce2-8414662dfecc', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'394c5830-7343-415c-9a58-5af0fd4886f2', N'e5603f45-7bff-4174-8ce2-8414662dfecc')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
