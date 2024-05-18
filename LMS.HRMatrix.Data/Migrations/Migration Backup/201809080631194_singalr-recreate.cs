namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class singalrrecreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ConnectionId = c.String(),
                    Time = c.DateTime(nullable: false),
                    UserAgent = c.String(),
                    Connected = c.Boolean(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Connections", new[] { "EmployeeId" });
            DropTable("dbo.Connections");
        }
    }
}
