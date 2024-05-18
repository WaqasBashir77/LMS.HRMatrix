namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomProperties", "MyModelID", "dbo.MyModels");
            DropForeignKey("dbo.MyDictionaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.CustomProperties", new[] { "MyModelID" });
            DropIndex("dbo.MyDictionaries", new[] { "EmployeeId" });
            DropTable("dbo.CustomProperties");
            DropTable("dbo.MyModels");
            DropTable("dbo.MyDictionaries");
            DropTable("dbo.PublishSources");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublishSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mykey = c.String(),
                        Myvalue = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyModels",
                c => new
                    {
                        MyModelID = c.Int(nullable: false, identity: true),
                        FixedProperty1 = c.String(),
                        FixedProperty2 = c.String(),
                    })
                .PrimaryKey(t => t.MyModelID);
            
            CreateTable(
                "dbo.CustomProperties",
                c => new
                    {
                        CustomPropertyID = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(),
                        PropertyValue = c.String(),
                        MyModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomPropertyID);
            
            CreateIndex("dbo.MyDictionaries", "EmployeeId");
            CreateIndex("dbo.CustomProperties", "MyModelID");
            AddForeignKey("dbo.MyDictionaries", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomProperties", "MyModelID", "dbo.MyModels", "MyModelID", cascadeDelete: true);
        }
    }
}
