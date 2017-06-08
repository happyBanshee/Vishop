namespace Vishop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedCustomerTable2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1955-12-03' WHERE Id = 7");
            Sql("UPDATE Customers SET Birthdate = '1984-12-12' WHERE Id = 8");
            Sql("UPDATE Customers SET Birthdate = '1955-01-02' WHERE Id = 9");
        }
        
        public override void Down()
        {
        }
    }
}
