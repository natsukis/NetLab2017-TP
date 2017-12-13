namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftControlFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShiftControls", "WorkedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftControls", "WorkedHours", c => c.Int(nullable: false));
        }
    }
}
