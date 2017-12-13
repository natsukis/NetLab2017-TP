namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShiftControl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShiftControls",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Day = c.DateTime(nullable: false),
                        Entry = c.DateTime(),
                        Exit = c.DateTime(),
                        WorkedHours = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShiftControls", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.ShiftControls", new[] { "Employee_ID" });
            DropTable("dbo.ShiftControls");
        }
    }
}
