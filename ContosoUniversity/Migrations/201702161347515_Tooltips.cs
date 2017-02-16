namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tooltips : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContextHelp", "Tooltip", c => c.String());
            AlterColumn("dbo.ContextHelp", "HelpText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContextHelp", "HelpText", c => c.String(nullable: false));
            DropColumn("dbo.ContextHelp", "Tooltip");
        }
    }
}
