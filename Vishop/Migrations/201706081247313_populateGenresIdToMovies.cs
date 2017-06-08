namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenresIdToMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            RenameColumn(table: "dbo.Movies", name: "genre_id", newName: "genresId");
            AlterColumn("dbo.Movies", "genresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genresId");
            AddForeignKey("dbo.Movies", "genresId", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genresId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genresId" });
            AlterColumn("dbo.Movies", "genresId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "genresId", newName: "genre_id");
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id");
        }
    }
}
