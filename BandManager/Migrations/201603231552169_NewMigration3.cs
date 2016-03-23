namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "OrderedYTD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "OrderedYTD");
        }
    }
}
