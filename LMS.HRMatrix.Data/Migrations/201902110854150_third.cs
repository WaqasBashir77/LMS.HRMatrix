namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mykey = c.String(),
                        Myvalue = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyDictionaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.MyDictionaries", new[] { "EmployeeId" });
            DropTable("dbo.MyDictionaries");
        }
    }
}
