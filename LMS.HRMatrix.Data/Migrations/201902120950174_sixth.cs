namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomFieldKeys",
                c => new
                    {
                        CustomFieldKeyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        type = c.String(),
                        DefaultValue = c.String(),
                        MinValue = c.String(),
                        MaxValue = c.String(),
                        CustomFieldID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomFieldKeyId);
            
            CreateTable(
                "dbo.CustomFields",
                c => new
                    {
                        CustomFieldID = c.Int(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        CustomFieldKey_CustomFieldKeyId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomFieldID)
                .ForeignKey("dbo.CustomFieldKeys", t => t.CustomFieldKey_CustomFieldKeyId)
                .Index(t => t.CustomFieldKey_CustomFieldKeyId);
            
            CreateTable(
                "dbo.CustomFieldKeyValues",
                c => new
                    {
                        CustomFieldKeyValueID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        CustomFieldKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomFieldKeyValueID)
                .ForeignKey("dbo.CustomFieldKeys", t => t.CustomFieldKeyId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomFieldKeyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomFieldKeyValues", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CustomFieldKeyValues", "CustomFieldKeyId", "dbo.CustomFieldKeys");
            DropForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFieldKeyValues", new[] { "CustomFieldKeyId" });
            DropIndex("dbo.CustomFieldKeyValues", new[] { "EmployeeId" });
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKey_CustomFieldKeyId" });
            DropTable("dbo.CustomFieldKeyValues");
            DropTable("dbo.CustomFields");
            DropTable("dbo.CustomFieldKeys");
        }
    }
}
