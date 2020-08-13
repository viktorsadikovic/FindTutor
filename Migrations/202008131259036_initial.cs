namespace FindTutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(),
                        Title = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Difficulty = c.String(nullable: false),
                        Description = c.String(),
                        Score = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Tutor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tutors", t => t.Tutor_Id)
                .Index(t => t.Tutor_Id);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Bio = c.String(),
                        Job = c.String(),
                        Score = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Reason = c.String(),
                        PrivateLesson_Id = c.Int(),
                        Submitter_Id = c.Int(),
                        Tutor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.PrivateLesson_Id)
                .ForeignKey("dbo.Customers", t => t.Submitter_Id)
                .ForeignKey("dbo.Tutors", t => t.Tutor_Id)
                .Index(t => t.PrivateLesson_Id)
                .Index(t => t.Submitter_Id)
                .Index(t => t.Tutor_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Tutor_Id", "dbo.Tutors");
            DropForeignKey("dbo.Reviews", "Submitter_Id", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "PrivateLesson_Id", "dbo.Announcements");
            DropForeignKey("dbo.Announcements", "Tutor_Id", "dbo.Tutors");
            DropIndex("dbo.Reviews", new[] { "Tutor_Id" });
            DropIndex("dbo.Reviews", new[] { "Submitter_Id" });
            DropIndex("dbo.Reviews", new[] { "PrivateLesson_Id" });
            DropIndex("dbo.Announcements", new[] { "Tutor_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Tutors");
            DropTable("dbo.Announcements");
        }
    }
}
