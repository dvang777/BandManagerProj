namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        ManagerID = c.String(),
                        manager_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Managers", t => t.manager_ID)
                .Index(t => t.manager_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "manager_ID", "dbo.Managers");
            DropIndex("dbo.Contacts", new[] { "manager_ID" });
            DropTable("dbo.Contacts");
        }
    }
}
