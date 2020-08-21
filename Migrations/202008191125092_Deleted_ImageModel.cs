namespace FindTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted_ImageModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tutors", "ProfilePicture_Id", "dbo.Images");
            DropForeignKey("dbo.Customers", "ProfilePicture_Id", "dbo.Images");
            DropIndex("dbo.Tutors", new[] { "ProfilePicture_Id" });
            DropIndex("dbo.Customers", new[] { "ProfilePicture_Id" });
            DropColumn("dbo.Tutors", "ProfilePicture_Id");
            DropColumn("dbo.Customers", "ProfilePicture_Id");
            DropTable("dbo.Images");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Customers", "ProfilePicture_Id", c => c.Int());
            AddColumn("dbo.Tutors", "ProfilePicture_Id", c => c.Int());
            CreateIndex("dbo.Customers", "ProfilePicture_Id");
            CreateIndex("dbo.Tutors", "ProfilePicture_Id");
            AddForeignKey("dbo.Customers", "ProfilePicture_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Tutors", "ProfilePicture_Id", "dbo.Images", "Id");
        }
    }
}
