namespace LMS.HRMatrix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatGroups", "NameBit", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatGroups", "NameBit");
        }
    }
}
