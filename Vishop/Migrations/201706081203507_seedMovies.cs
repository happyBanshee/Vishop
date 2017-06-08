namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedMovies : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Movies (name,genre,releaseDate,addedDate) VALUES ('The Boss Baby',' Animation, Comedy, Family',' 31 March 2017',GETDATE())");
            Sql("INSERT INTO Movies (name,genre,releaseDate,addedDate) VALUES ('The Hero',' Comedy, Drama','9 June 2017',GETDATE())");
            Sql("INSERT INTO Movies (name,genre,releaseDate,addedDate) VALUES ('Wonder Woman',' Action, Adventure, Fantasy ',' 2 June 2017',GETDATE())");
        }

        public override void Down()
        {
        }
    }
}
