namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextHelpProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContextHelp", "Property", c => c.String(maxLength: 100));
            DropColumn("dbo.ContextHelp", "PropertyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContextHelp", "PropertyName", c => c.String(maxLength: 100));
            DropColumn("dbo.ContextHelp", "Property");
        }
    }
}
