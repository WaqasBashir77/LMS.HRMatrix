namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signalrtest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Connections", new[] { "EmployeeId" });
            DropColumn("dbo.Connections", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Connections", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Connections", "EmployeeId");
            AddForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
