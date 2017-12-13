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
                        CountryID = c.Int(nullable: false),
                        CountryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EntryDate = c.DateTime(nullable: false),
                        Country_CountryID = c.Int(nullable: false),
                        CurrentShift_ShiftID = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.CurrentShift_ShiftID, cascadeDelete: true)
                .Index(t => t.Country_CountryID)
                .Index(t => t.CurrentShift_ShiftID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftID = c.String(nullable: false, maxLength: 5),
                        InitialHour = c.Short(nullable: false),
                        EndingHour = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CurrentShift_ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.Employees", "Country_CountryID", "dbo.Countries");
            DropIndex("dbo.Employees", new[] { "CurrentShift_ShiftID" });
            DropIndex("dbo.Employees", new[] { "Country_CountryID" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Employees");
            DropTable("dbo.Countries");
        }
    }
}
