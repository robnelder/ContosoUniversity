namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextHelpController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContextHelp", "Controller", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ContextHelp", "Action", c => c.String(maxLength: 100));
            DropColumn("dbo.ContextHelp", "ModelName");
            DropColumn("dbo.ContextHelp", "ViewName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContextHelp", "ViewName", c => c.String(maxLength: 100));
            AddColumn("dbo.ContextHelp", "ModelName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.ContextHelp", "Action");
            DropColumn("dbo.ContextHelp", "Controller");
        }
    }
}
