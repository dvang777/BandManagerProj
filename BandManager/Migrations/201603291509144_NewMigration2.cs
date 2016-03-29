namespace BandManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ManagerID = c.String(),
                        Managers_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.Managers_ID)
                .Index(t => t.Managers_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Managers_ID", "dbo.Managers");
            DropIndex("dbo.Appointments", new[] { "Managers_ID" });
            DropTable("dbo.Appointments");
        }
    }
}
