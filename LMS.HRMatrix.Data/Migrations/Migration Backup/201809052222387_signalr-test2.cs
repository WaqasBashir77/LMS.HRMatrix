namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signalrtest2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Connections");
            AlterColumn("dbo.Connections", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Connections", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Connections");
            AlterColumn("dbo.Connections", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Connections", "Id");
        }
    }
}
