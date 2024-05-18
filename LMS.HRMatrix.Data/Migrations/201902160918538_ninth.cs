namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ninth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKey_CustomFieldKeyId" });
            RenameColumn(table: "dbo.CustomFields", name: "CustomFieldKey_CustomFieldKeyId", newName: "CustomFieldKeyID");
            AlterColumn("dbo.CustomFields", "CustomFieldKeyID", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomFields", "CustomFieldKeyID");
            AddForeignKey("dbo.CustomFields", "CustomFieldKeyID", "dbo.CustomFieldKeys", "CustomFieldKeyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomFields", "CustomFieldKeyID", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKeyID" });
            AlterColumn("dbo.CustomFields", "CustomFieldKeyID", c => c.Int());
            RenameColumn(table: "dbo.CustomFields", name: "CustomFieldKeyID", newName: "CustomFieldKey_CustomFieldKeyId");
            CreateIndex("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId");
            AddForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys", "CustomFieldKeyId");
        }
    }
}
