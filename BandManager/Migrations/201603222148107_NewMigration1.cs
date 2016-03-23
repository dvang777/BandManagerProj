namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Begin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "End");
            DropColumn("dbo.Events", "Begin");
        }
    }
}
