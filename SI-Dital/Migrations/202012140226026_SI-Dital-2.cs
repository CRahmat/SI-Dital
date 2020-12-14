namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileDocuments", "File", c => c.Binary());
            DropColumn("dbo.FileDocuments", "FileUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileDocuments", "FileUrl", c => c.String());
            DropColumn("dbo.FileDocuments", "File");
        }
    }
}
