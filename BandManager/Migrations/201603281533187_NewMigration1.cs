namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Budgets", "BandID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Budgets", "BandID");
            AddForeignKey("dbo.Budgets", "BandID", "dbo.Bands", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "BandID", "dbo.Bands");
            DropIndex("dbo.Budgets", new[] { "BandID" });
            AlterColumn("dbo.Budgets", "BandID", c => c.String());
        }
    }
}
