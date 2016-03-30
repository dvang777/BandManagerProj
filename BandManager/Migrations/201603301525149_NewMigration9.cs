namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TotalItemSold", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "TotalRevenue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Inventories", "SoldQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Inventories", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Inventories", "TotalSold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "TotalSold");
            DropColumn("dbo.Inventories", "Price");
            DropColumn("dbo.Inventories", "SoldQuantity");
            DropColumn("dbo.Events", "TotalRevenue");
            DropColumn("dbo.Events", "TotalItemSold");
        }
    }
}
