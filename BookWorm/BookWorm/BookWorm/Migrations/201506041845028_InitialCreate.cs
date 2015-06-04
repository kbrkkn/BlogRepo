namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        BAuthor = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "BookID", "dbo.Book");
            DropForeignKey("dbo.Enrollment", "AuthorID", "dbo.Author");
            DropIndex("dbo.Enrollment", new[] { "AuthorID" });
            DropIndex("dbo.Enrollment", new[] { "BookID" });
            DropTable("dbo.Book");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Author");
        }
    }
}
