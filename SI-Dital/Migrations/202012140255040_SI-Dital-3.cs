namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "FileDocuments_IdFileDocument", c => c.String(maxLength: 128));
            CreateIndex("dbo.Documents", "FileDocuments_IdFileDocument");
            AddForeignKey("dbo.Documents", "FileDocuments_IdFileDocument", "dbo.FileDocuments", "IdFileDocument");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "FileDocuments_IdFileDocument", "dbo.FileDocuments");
            DropIndex("dbo.Documents", new[] { "FileDocuments_IdFileDocument" });
            DropColumn("dbo.Documents", "FileDocuments_IdFileDocument");
        }
    }
}
