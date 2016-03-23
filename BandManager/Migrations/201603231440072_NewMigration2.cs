namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "QuantitySold", c => c.Int(nullable: false));
            AddColumn("dbo.Inventories", "QuantityIncoming", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Quantity", c => c.String());
            DropColumn("dbo.Inventories", "QuantityIncoming");
            DropColumn("dbo.Inventories", "QuantitySold");
        }
    }
}
