namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldsSignature : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            DropIndex("dbo.Movies", new[] { "genresId" });
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.Movies", "GenresId");
            DropColumn("dbo.Movies", "numbeInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "numbeInStock", c => c.Int(nullable: false));
            DropIndex("dbo.Movies", new[] { "GenresId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            CreateIndex("dbo.Movies", "genresId");
            CreateIndex("dbo.Customers", "membershipTypeId");
        }
    }
}
