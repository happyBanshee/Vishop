namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setGenreToMovie : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET genresId = 1 WHERE id = 1");
            Sql("UPDATE Movies SET genresId = 1 WHERE id = 2");
            Sql("UPDATE Movies SET genresId = 2 WHERE id = 3");
            Sql("UPDATE Movies SET genresId = 3 WHERE id = 4");
            Sql("UPDATE Movies SET genresId = 2 WHERE id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
