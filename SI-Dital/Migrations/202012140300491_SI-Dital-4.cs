namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "FileDocuments_IdFileDocument", "dbo.FileDocuments");
            DropIndex("dbo.Documents", new[] { "FileDocuments_IdFileDocument" });
            AddColumn("dbo.DocumentGroups", "FileDocuments_IdFileDocument", c => c.String(maxLength: 128));
            CreateIndex("dbo.DocumentGroups", "FileDocuments_IdFileDocument");
            AddForeignKey("dbo.DocumentGroups", "FileDocuments_IdFileDocument", "dbo.FileDocuments", "IdFileDocument");
            DropColumn("dbo.Documents", "FileDocuments_IdFileDocument");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "FileDocuments_IdFileDocument", c => c.String(maxLength: 128));
            DropForeignKey("dbo.DocumentGroups", "FileDocuments_IdFileDocument", "dbo.FileDocuments");
            DropIndex("dbo.DocumentGroups", new[] { "FileDocuments_IdFileDocument" });
            DropColumn("dbo.DocumentGroups", "FileDocuments_IdFileDocument");
            CreateIndex("dbo.Documents", "FileDocuments_IdFileDocument");
            AddForeignKey("dbo.Documents", "FileDocuments_IdFileDocument", "dbo.FileDocuments", "IdFileDocument");
        }
    }
}
