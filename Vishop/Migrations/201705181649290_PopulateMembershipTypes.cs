namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "name", c => c.String(nullable: false, maxLength: 255));
            Sql("INSERT INTO MembershipTypes (Id, SignupFee,DurationMonths,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee,DurationMonths,DiscountRate) VALUES (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee,DurationMonths,DiscountRate) VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee,DurationMonths,DiscountRate) VALUES (4,300,12,20)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "name", c => c.String());
        }
    }
}