namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.Employees", "CurrentShift_ShiftID", "dbo.Shifts");
            DropIndex("dbo.Employees", new[] { "CurrentShift_ShiftID" });
            RenameColumn(table: "dbo.Employees", name: "Country_CountryID", newName: "Country_ID");
            RenameColumn(table: "dbo.Employees", name: "CurrentShift_ShiftID", newName: "CurrentShift_ID");
            RenameIndex(table: "dbo.Employees", name: "IX_Country_CountryID", newName: "IX_Country_ID");
            DropPrimaryKey("dbo.Countries");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Shifts");
            AddColumn("dbo.Countries", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employees", "CurrentShift_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Countries", "ID");
            AddPrimaryKey("dbo.Employees", "ID");
            AddPrimaryKey("dbo.Shifts", "ID");
            CreateIndex("dbo.Employees", "CurrentShift_ID");
            AddForeignKey("dbo.Employees", "Country_ID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "CurrentShift_ID", "dbo.Shifts", "ID", cascadeDelete: true);
            DropColumn("dbo.Countries", "CountryID");
            DropColumn("dbo.Employees", "EmployeeID");
            DropColumn("dbo.Shifts", "ShiftID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "ShiftID", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            AddColumn("dbo.Countries", "CountryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "CurrentShift_ID", "dbo.Shifts");
            DropForeignKey("dbo.Employees", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Employees", new[] { "CurrentShift_ID" });
            DropPrimaryKey("dbo.Shifts");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Employees", "CurrentShift_ID", c => c.String(nullable: false, maxLength: 5));
            DropColumn("dbo.Shifts", "Name");
            DropColumn("dbo.Shifts", "ID");
            DropColumn("dbo.Employees", "ID");
            DropColumn("dbo.Countries", "ID");
            AddPrimaryKey("dbo.Shifts", "ShiftID");
            AddPrimaryKey("dbo.Employees", "EmployeeID");
            AddPrimaryKey("dbo.Countries", "CountryID");
            RenameIndex(table: "dbo.Employees", name: "IX_Country_ID", newName: "IX_Country_CountryID");
            RenameColumn(table: "dbo.Employees", name: "CurrentShift_ID", newName: "CurrentShift_ShiftID");
            RenameColumn(table: "dbo.Employees", name: "Country_ID", newName: "Country_CountryID");
            CreateIndex("dbo.Employees", "CurrentShift_ShiftID");
            AddForeignKey("dbo.Employees", "CurrentShift_ShiftID", "dbo.Shifts", "ShiftID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Country_CountryID", "dbo.Countries", "CountryID", cascadeDelete: true);
        }
    }
}
