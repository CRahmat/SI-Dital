namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SI_Dital5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citizens", "DOB", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citizens", "DOB");
        }
    }
}
