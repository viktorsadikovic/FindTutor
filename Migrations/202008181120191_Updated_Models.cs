namespace FindTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Announcements", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Announcements", "Customer_Id");
            AddForeignKey("dbo.Announcements", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Announcements", new[] { "Customer_Id" });
            DropColumn("dbo.Announcements", "Customer_Id");
            DropTable("dbo.Images");
        }
    }
}
