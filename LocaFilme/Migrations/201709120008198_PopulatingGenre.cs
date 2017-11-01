namespace LocaFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Action') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Adventure') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Animation') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Comedy') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Crime') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Drama') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Fantasy') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Historical') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Historical fiction') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Horror') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Magical realism') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Mystery') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Paranoid') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Philosophical') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Political') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Romance') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Saga') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Satire') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Science fiction') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Slice of Life') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Speculative') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Thriller') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ('Urban') ");
            Sql("INSERT INTO GENRES ( GenreName) VALUES ( 'Western') ");

        }
        
        public override void Down()
        {
        }
    }
}
