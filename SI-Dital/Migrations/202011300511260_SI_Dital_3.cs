namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SI_Dital_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "Status");
        }
    }
}
