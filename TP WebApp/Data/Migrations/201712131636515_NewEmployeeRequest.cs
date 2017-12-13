namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEmployeeRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ValueByHour", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ValueByHour");
        }
    }
}
