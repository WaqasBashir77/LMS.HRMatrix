namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys");
            DropIndex("dbo.CustomFields", new[] { "CustomFieldKey_CustomFieldKeyId" });
            DropColumn("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", c => c.Int());
            CreateIndex("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId");
            AddForeignKey("dbo.CustomFields", "CustomFieldKey_CustomFieldKeyId", "dbo.CustomFieldKeys", "CustomFieldKeyId");
        }
    }
}
