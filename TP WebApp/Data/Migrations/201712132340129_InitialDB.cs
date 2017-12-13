namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EntryDate = c.DateTime(nullable: false),
                        ValueByHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Country_ID = c.Int(nullable: false),
                        CurrentShift_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.CurrentShift_ID, cascadeDelete: true)
                .Index(t => t.Country_ID)
                .Index(t => t.CurrentShift_ID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        InitialHour = c.Short(nullable: false),
                        EndingHour = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShiftControls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Entry = c.DateTime(),
                        Exit = c.DateTime(),
                        WorkedHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShiftControls", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CurrentShift_ID", "dbo.Shifts");
            DropForeignKey("dbo.Employees", "Country_ID", "dbo.Countries");
            DropIndex("dbo.ShiftControls", new[] { "Employee_ID" });
            DropIndex("dbo.Employees", new[] { "CurrentShift_ID" });
            DropIndex("dbo.Employees", new[] { "Country_ID" });
            DropTable("dbo.ShiftControls");
            DropTable("dbo.Shifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Countries");
        }
    }
}
