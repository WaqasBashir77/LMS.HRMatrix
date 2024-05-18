namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SignalRAlter1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Connections", "ConnectionId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Connections", "ConnectionId", c => c.Int(nullable: false));
        }
    }
}
