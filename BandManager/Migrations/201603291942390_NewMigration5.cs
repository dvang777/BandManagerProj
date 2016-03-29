namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PhoneNumber", c => c.String());
            AddColumn("dbo.Members", "Address", c => c.String());
            AddColumn("dbo.Members", "City", c => c.String());
            AddColumn("dbo.Members", "State", c => c.String());
            AddColumn("dbo.Members", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "ZipCode");
            DropColumn("dbo.Members", "State");
            DropColumn("dbo.Members", "City");
            DropColumn("dbo.Members", "Address");
            DropColumn("dbo.Members", "PhoneNumber");
        }
    }
}
