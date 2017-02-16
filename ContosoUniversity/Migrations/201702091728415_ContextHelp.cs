namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextHelp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContextHelp",
                c => new
                    {
                        ContextHelpID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(nullable: false, maxLength: 100),
                        ViewName = c.String(maxLength: 100),
                        PropertyName = c.String(maxLength: 100),
                        HelpText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContextHelpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContextHelp");
        }
    }
}
