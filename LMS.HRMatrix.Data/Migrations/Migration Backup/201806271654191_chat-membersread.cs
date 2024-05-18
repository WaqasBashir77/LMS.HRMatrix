namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatmembersread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "MembersRead", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chats", "MembersRead");
        }
    }
}
