namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        signupFee = c.Short(nullable: false),
                        durationMonths = c.Byte(nullable: false),
                        discountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Customers", "isSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "membershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "membershipTypeId");
            AddForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            DropColumn("dbo.Customers", "membershipTypeId");
            DropColumn("dbo.Customers", "isSubscribedToNewsletter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
