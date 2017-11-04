namespace LocaFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingGenreIdAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GereId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GereId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
