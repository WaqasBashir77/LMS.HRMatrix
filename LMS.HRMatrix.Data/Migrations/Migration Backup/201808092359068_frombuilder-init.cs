namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frombuilderinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.form",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Slug = c.String(nullable: false, maxLength: 50),
                        Status = c.String(maxLength: 50),
                        ConfirmationMessage = c.String(nullable: false, maxLength: 300),
                        DateAdded = c.DateTime(),
                        Theme = c.String(maxLength: 50),
                        NotificationEmail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.form_form_fields",
                c => new
                    {
                        formId = c.Int(nullable: false),
                        fieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.formId, t.fieldId })
                .ForeignKey("dbo.form_fields", t => t.fieldId, cascadeDelete: true)
                .ForeignKey("dbo.form", t => t.formId, cascadeDelete: true)
                .Index(t => t.formId)
                .Index(t => t.fieldId);
            
            CreateTable(
                "dbo.form_fields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(maxLength: 50),
                        Text = c.String(maxLength: 100),
                        FieldType = c.String(maxLength: 20, unicode: false),
                        IsRequired = c.Boolean(),
                        MaxChars = c.Int(),
                        HoverText = c.String(maxLength: 150),
                        Hint = c.String(maxLength: 150),
                        SubLabel = c.String(maxLength: 50),
                        Size = c.String(maxLength: 10, unicode: false),
                        SelectedOption = c.String(nullable: false, maxLength: 50),
                        Columns = c.Int(),
                        Rows = c.Int(),
                        Options = c.String(maxLength: 300),
                        Validation = c.String(maxLength: 50, unicode: false),
                        DomId = c.Int(),
                        Order = c.Int(),
                        MinimumAge = c.Int(),
                        MaximumAge = c.Int(),
                        HelpText = c.String(maxLength: 50),
                        DateAdded = c.DateTime(nullable: false),
                        MaxFilesizeInKb = c.Int(),
                        ValidFileExtensions = c.String(maxLength: 50),
                        MinFilesizeInKb = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.form_field_values",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FieldId = c.Int(nullable: false),
                        EntryId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 500),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.form_fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.form_form_fields", "formId", "dbo.form");
            DropForeignKey("dbo.form_form_fields", "fieldId", "dbo.form_fields");
            DropForeignKey("dbo.form_field_values", "FieldId", "dbo.form_fields");
            DropIndex("dbo.form_field_values", new[] { "FieldId" });
            DropIndex("dbo.form_form_fields", new[] { "fieldId" });
            DropIndex("dbo.form_form_fields", new[] { "formId" });
            DropTable("dbo.form_field_values");
            DropTable("dbo.form_fields");
            DropTable("dbo.form_form_fields");
            DropTable("dbo.form");
        }
    }
}
