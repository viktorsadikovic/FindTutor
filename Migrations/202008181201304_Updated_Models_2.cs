namespace FindTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Models_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "ProfilePicture_Id", c => c.Int());
            AddColumn("dbo.Customers", "ProfilePicture_Id", c => c.Int());
            CreateIndex("dbo.Tutors", "ProfilePicture_Id");
            CreateIndex("dbo.Customers", "ProfilePicture_Id");
            AddForeignKey("dbo.Tutors", "ProfilePicture_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Customers", "ProfilePicture_Id", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProfilePicture_Id", "dbo.Images");
            DropForeignKey("dbo.Tutors", "ProfilePicture_Id", "dbo.Images");
            DropIndex("dbo.Customers", new[] { "ProfilePicture_Id" });
            DropIndex("dbo.Tutors", new[] { "ProfilePicture_Id" });
            DropColumn("dbo.Customers", "ProfilePicture_Id");
            DropColumn("dbo.Tutors", "ProfilePicture_Id");
        }
    }
}
