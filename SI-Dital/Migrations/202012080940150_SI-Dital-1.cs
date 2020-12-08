namespace SI_Dital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIDital1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Registered = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        IsBanned = c.Boolean(nullable: false),
                        RegistrationStatus = c.Int(nullable: false),
                        Descriptions = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        IdDocument = c.String(nullable: false, maxLength: 128),
                        Descriptions = c.String(),
                        Status = c.Int(nullable: false),
                        ApprovedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        Deleted = c.DateTimeOffset(nullable: false, precision: 7),
                        Published = c.DateTimeOffset(nullable: false, precision: 7),
                        Approved = c.DateTimeOffset(nullable: false, precision: 7),
                        ApprovedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                        DocumentGroup_Permalink = c.String(maxLength: 128),
                        PublishedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        Citizens_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdDocument)
                .ForeignKey("dbo.AspNetUsers", t => t.ApprovedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy_Id)
                .ForeignKey("dbo.DocumentGroups", t => t.DocumentGroup_Permalink)
                .ForeignKey("dbo.AspNetUsers", t => t.PublishedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.Citizens", t => t.Citizens_Id)
                .Index(t => t.ApprovedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.DeletedBy_Id)
                .Index(t => t.DocumentGroup_Permalink)
                .Index(t => t.PublishedBy_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.Citizens_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DocumentGroups",
                c => new
                    {
                        Permalink = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Permalink)
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
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        IdJob = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        Deleted = c.DateTimeOffset(nullable: false, precision: 7),
                        Published = c.DateTimeOffset(nullable: false, precision: 7),
                        Approved = c.DateTimeOffset(nullable: false, precision: 7),
                        ApprovedBy_Id = c.String(maxLength: 128),
                        CreatedBy_Id = c.String(maxLength: 128),
                        DeletedBy_Id = c.String(maxLength: 128),
                        PublishedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdJob)
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
            
            CreateTable(
                "dbo.RT",
                c => new
                    {
                        IdRT = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Chairman = c.String(),
                        IsActive = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.IdRT)
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
            
            CreateTable(
                "dbo.RW",
                c => new
                    {
                        IdRW = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Chairman = c.String(),
                        IsActive = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.IdRW)
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
            
            CreateTable(
                "dbo.Hamlet",
                c => new
                    {
                        IdHamlet = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Chairman = c.String(),
                        IsActive = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.IdHamlet)
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EditedBy_Id = c.String(maxLength: 128),
                        Job_IdJob = c.Int(),
                        RegisteredBy_Id = c.String(maxLength: 128),
                        RT_IdRT = c.String(maxLength: 128),
                        RW_IdRW = c.String(maxLength: 128),
                        NIK = c.String(),
                        Password = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MaritalStatus = c.Boolean(nullable: false),
                        Citizenship = c.String(),
                        Religion = c.Int(nullable: false),
                        DOB = c.DateTimeOffset(nullable: false, precision: 7),
                        FullName = c.String(),
                        Institution = c.String(),
                        Avatar = c.String(),
                        Address = c.String(),
                        Edited = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EditedBy_Id)
                .ForeignKey("dbo.Job", t => t.Job_IdJob)
                .ForeignKey("dbo.AspNetUsers", t => t.RegisteredBy_Id)
                .ForeignKey("dbo.RT", t => t.RT_IdRT)
                .ForeignKey("dbo.RW", t => t.RW_IdRW)
                .Index(t => t.Id)
                .Index(t => t.EditedBy_Id)
                .Index(t => t.Job_IdJob)
                .Index(t => t.RegisteredBy_Id)
                .Index(t => t.RT_IdRT)
                .Index(t => t.RW_IdRW);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citizens", "RW_IdRW", "dbo.RW");
            DropForeignKey("dbo.Citizens", "RT_IdRT", "dbo.RT");
            DropForeignKey("dbo.Citizens", "RegisteredBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citizens", "Job_IdJob", "dbo.Job");
            DropForeignKey("dbo.Citizens", "EditedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citizens", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Hamlet", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hamlet", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hamlet", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hamlet", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hamlet", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FileDocuments", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RW", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RT", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Job", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "Citizens_Id", "dbo.Citizens");
            DropForeignKey("dbo.Documents", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "DocumentGroup_Permalink", "dbo.DocumentGroups");
            DropForeignKey("dbo.DocumentGroups", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DocumentGroups", "PublishedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DocumentGroups", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DocumentGroups", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DocumentGroups", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "DeletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Citizens", new[] { "RW_IdRW" });
            DropIndex("dbo.Citizens", new[] { "RT_IdRT" });
            DropIndex("dbo.Citizens", new[] { "RegisteredBy_Id" });
            DropIndex("dbo.Citizens", new[] { "Job_IdJob" });
            DropIndex("dbo.Citizens", new[] { "EditedBy_Id" });
            DropIndex("dbo.Citizens", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Hamlet", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Hamlet", new[] { "PublishedBy_Id" });
            DropIndex("dbo.Hamlet", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Hamlet", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Hamlet", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "PublishedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "DeletedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.FileDocuments", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.RW", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.RW", new[] { "PublishedBy_Id" });
            DropIndex("dbo.RW", new[] { "DeletedBy_Id" });
            DropIndex("dbo.RW", new[] { "CreatedBy_Id" });
            DropIndex("dbo.RW", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.RT", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.RT", new[] { "PublishedBy_Id" });
            DropIndex("dbo.RT", new[] { "DeletedBy_Id" });
            DropIndex("dbo.RT", new[] { "CreatedBy_Id" });
            DropIndex("dbo.RT", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.Job", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Job", new[] { "PublishedBy_Id" });
            DropIndex("dbo.Job", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Job", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Job", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "PublishedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "DeletedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "CreatedBy_Id" });
            DropIndex("dbo.DocumentGroups", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Documents", new[] { "Citizens_Id" });
            DropIndex("dbo.Documents", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Documents", new[] { "PublishedBy_Id" });
            DropIndex("dbo.Documents", new[] { "DocumentGroup_Permalink" });
            DropIndex("dbo.Documents", new[] { "DeletedBy_Id" });
            DropIndex("dbo.Documents", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Documents", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.Citizens");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Hamlet");
            DropTable("dbo.FileDocuments");
            DropTable("dbo.RW");
            DropTable("dbo.RT");
            DropTable("dbo.Job");
            DropTable("dbo.DocumentGroups");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Documents");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
