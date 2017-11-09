namespace LocaFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7970c564-f2fc-4904-a534-5d1b10e9b567', N'admin@movie.com', 0, N'AJz26n+OmKnL4+3Qw6NJ0ncduznPhcFcKJNgBbUjRCerCw5HqNTmm3yVfo+vV1xvPg==', N'520faf29-a869-4d26-a6d8-bd35d84c3ec4', NULL, 0, 0, NULL, 1, 0, N'admin@movie.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd6242104-b681-4503-96c6-628b8e2c66de', N'guest@movie.com', 0, N'ADXqk4r77APoyP8Pm69ekIx84ntIkRc/cF/S4iiyPdKuCx6NLCUWRAzUBqb4fySYLQ==', N'd6427a83-c49d-4e0e-b0aa-1556968e0c46', NULL, 0, 0, NULL, 1, 0, N'guest@movie.com')
        
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'354f2821-47de-48fa-b567-96d10d58795e', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7970c564-f2fc-4904-a534-5d1b10e9b567', N'354f2821-47de-48fa-b567-96d10d58795e')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
