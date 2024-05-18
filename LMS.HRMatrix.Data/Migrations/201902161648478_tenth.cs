namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomFields", "CustomFieldKeyID", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKeyID" });
            RenameColumn(table: "dbo.CustomFields", name: "CustomFieldKeyID", newName: "CustomFieldKey_CustomFieldKeyId");
            AlterColumn("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", c => c.Int());
            CreateIndex("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId");
            AddForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys", "CustomFieldKeyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKey_CustomFieldKeyId" });
            AlterColumn("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CustomFields", name: "CustomFieldKey_CustomFieldKeyId", newName: "CustomFieldKeyID");
            CreateIndex("dbo.CustomFields", "CustomFieldKeyID");
            AddForeignKey("dbo.CustomFields", "CustomFieldKeyID", "dbo.CustomFieldKeys", "CustomFieldKeyId", cascadeDelete: true);
        }
    }
}
