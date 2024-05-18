namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomProperties",
                c => new
                    {
                        CustomPropertyID = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(),
                        PropertyValue = c.String(),
                        MyModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomPropertyID)
                .ForeignKey("dbo.MyModels", t => t.MyModelID, cascadeDelete: true)
                .Index(t => t.MyModelID);
            
            CreateTable(
                "dbo.MyModels",
                c => new
                    {
                        MyModelID = c.Int(nullable: false, identity: true),
                        FixedProperty1 = c.String(),
                        FixedProperty2 = c.String(),
                    })
                .PrimaryKey(t => t.MyModelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomProperties", "MyModelID", "dbo.MyModels");
            DropIndex("dbo.CustomProperties", new[] { "MyModelID" });
            DropTable("dbo.MyModels");
            DropTable("dbo.CustomProperties");
        }
    }
}
