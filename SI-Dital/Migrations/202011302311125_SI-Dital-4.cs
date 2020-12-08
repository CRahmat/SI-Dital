namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDocuments",
                c => new
                    {
                        IdFileDocument = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        FileUrl = c.String(),
                        LogoXPosition = c.Double(nullable: false),
                        LogoYPosition = c.Double(nullable: false),
                        NameXPosition = c.Double(nullable: false),
                        NameYPosition = c.Double(nullable: false),
                        NameFontSize = c.Double(nullable: false),
                        QRXPosition = c.Double(nullable: false),
                        QRYPosition = c.Double(nullable: false),
                        DocumentNameXPosition = c.Double(nullable: false),
                        DocumentNameYPosition = c.Double(nullable: false),
                        DocumentNameFontSize = c.Double(nullable: false),
                        DocumentDateXPosition = c.Double(nullable: false),
                        DocumentDateYPosition = c.Double(nullable: false),
                        DocumentDateFontSize = c.Double(nullable: false),
                        DocumentLocationXPosition = c.Double(nullable: false),
                        DocumentLocationYPosition = c.Double(nullable: false),
                        DocumentLocationFontSize = c.Double(nullable: false),
                        CitizenRoleXPosition = c.Double(nullable: false),
                        CitizenRoleYPosition = c.Double(nullable: false),
                        CitizenRoleFontSize = c.Double(nullable: false),
                        FontSize = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        Deleted = c.DateTimeOffset(nullable: false, precision: 7),
                        Published = c.DateTimeOffset(nullable: false, precision: 7),
                        Approved = c.DateTimeOffset(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        ApprovedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                        PublishedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdFileDocument)
                .ForeignKey("dbo.AspNetUsers", t => t.ApprovedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PublishedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.ApprovedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.DeletedBy_Id)
                .Index(t => t.PublishedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            AddColumn("dbo.Documents", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.RT", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.RT", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.RT", "ApprovedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.RW", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.RW", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.RW", "ApprovedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Job", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Job", "ApprovedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.DocumentGroups", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.DocumentGroups", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.DocumentGroups", "ApprovedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Hamlet", "Approved", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Hamlet", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Hamlet", "ApprovedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RT", "ApprovedBy_Id");
            CreateIndex("dbo.RW", "ApprovedBy_Id");
            CreateIndex("dbo.Job", "ApprovedBy_Id");
            CreateIndex("dbo.DocumentGroups", "ApprovedBy_Id");
            CreateIndex("dbo.Hamlet", "ApprovedBy_Id");
            AddForeignKey("dbo.RT", "ApprovedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.RW", "ApprovedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Job", "ApprovedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DocumentGroups", "ApprovedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Hamlet", "ApprovedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hamlet", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DocumentGroups", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Hamlet", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "PublishedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "DeletedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.Job", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.RW", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.RT", new[] { "ApprovedBy_Id" });
            DropColumn("dbo.Hamlet", "ApprovedBy_Id");
            DropColumn("dbo.Hamlet", "Status");
            DropColumn("dbo.Hamlet", "Approved");
            DropColumn("dbo.DocumentGroups", "ApprovedBy_Id");
            DropColumn("dbo.DocumentGroups", "Status");
            DropColumn("dbo.DocumentGroups", "Approved");
            DropColumn("dbo.Job", "ApprovedBy_Id");
            DropColumn("dbo.Job", "Approved");
            DropColumn("dbo.RW", "ApprovedBy_Id");
            DropColumn("dbo.RW", "Status");
            DropColumn("dbo.RW", "Approved");
            DropColumn("dbo.RT", "ApprovedBy_Id");
            DropColumn("dbo.RT", "Status");
            DropColumn("dbo.RT", "Approved");
            DropColumn("dbo.Documents", "Approved");
            DropTable("dbo.FileDocuments");
        }
    }
}
