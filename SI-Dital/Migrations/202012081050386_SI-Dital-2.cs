namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.Citizens", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citizens", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
