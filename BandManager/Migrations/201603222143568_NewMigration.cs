namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "band_ID", newName: "BandId");
            RenameColumn(table: "dbo.Inventories", name: "band_ID", newName: "BandId");
            RenameIndex(table: "dbo.Events", name: "IX_band_ID", newName: "IX_BandId");
            RenameIndex(table: "dbo.Inventories", name: "IX_band_ID", newName: "IX_BandId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Inventories", name: "IX_BandId", newName: "IX_band_ID");
            RenameIndex(table: "dbo.Events", name: "IX_BandId", newName: "IX_band_ID");
            RenameColumn(table: "dbo.Inventories", name: "BandId", newName: "band_ID");
            RenameColumn(table: "dbo.Events", name: "BandId", newName: "band_ID");
        }
    }
}
