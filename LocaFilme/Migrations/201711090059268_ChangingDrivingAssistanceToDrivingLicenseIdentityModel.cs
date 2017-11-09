namespace LocaFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDrivingAssistanceToDrivingLicenseIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingAssistance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingAssistance", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
