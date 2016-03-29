namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Budgets", "Name", c => c.String());
            DropColumn("dbo.Budgets", "DepositAmount");
            DropColumn("dbo.Budgets", "DepositDescription");
            DropColumn("dbo.Budgets", "DepositDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Budgets", "DepositDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Budgets", "DepositDescription", c => c.String());
            AddColumn("dbo.Budgets", "DepositAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Budgets", "Name");
        }
    }
}
