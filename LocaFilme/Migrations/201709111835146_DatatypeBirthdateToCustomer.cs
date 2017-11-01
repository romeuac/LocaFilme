namespace LocaFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
