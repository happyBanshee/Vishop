namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldsToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genre", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "addedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "numbeInStock", c => c.Int(nullable: false));

            Sql("INSERT INTO Movies (name, genre,releaseDate,addedDate,numbeInStock) VALUES ('Stepford wives','Comedy','June 11, 2004',GETDATE(),1)");
            Sql("INSERT INTO Movies (name, genre,releaseDate,addedDate,numbeInStock) VALUES ('John Wick','Drama','24 October 2014',GETDATE(),1)");

        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "numbeInStock");
            DropColumn("dbo.Movies", "addedDate");
            DropColumn("dbo.Movies", "releaseDate");
            DropColumn("dbo.Movies", "genre");
        }
    }
}
