namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ConfirmationToken = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        LastPasswordFailureDate = c.DateTime(nullable: false),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordChangedDate = c.DateTime(nullable: false),
                        PasswordSalt = c.String(),
                        PasswordVerificationToken = c.String(),
                        PasswordVerificationTokenExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        MaxPerson = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Time = c.String(nullable: false),
                        CalenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calenders", t => t.CalenderId, cascadeDelete: true)
                .Index(t => t.CalenderId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Calenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        WebPage = c.String(),
                        Description = c.String(),
                        AddressId = c.Int(),
                        LogotypeImageId = c.Int(),
                        CompanyId = c.Int(),
                        CompanyImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Images", t => t.LogotypeImageId)
                .ForeignKey("dbo.Images", t => t.CompanyImage_Id)
                .Index(t => t.AddressId)
                .Index(t => t.LogotypeImageId)
                .Index(t => t.CompanyImage_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        PostalNumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompanyAdmins", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CompanyImage_Id" });
            DropIndex("dbo.Companies", new[] { "LogotypeImageId" });
            DropIndex("dbo.Companies", new[] { "AddressId" });
            DropIndex("dbo.Calenders", new[] { "CompanyID" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "ActivityId" });
            DropIndex("dbo.Activities", new[] { "CalenderId" });
            DropForeignKey("dbo.CompanyAdmins", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyImage_Id", "dbo.Images");
            DropForeignKey("dbo.Companies", "LogotypeImageId", "dbo.Images");
            DropForeignKey("dbo.Companies", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Calenders", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.User");
            DropForeignKey("dbo.Bookings", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Activities", "CalenderId", "dbo.Calenders");
            DropTable("dbo.Tests");
            DropTable("dbo.CompanyAdmins");
            DropTable("dbo.Images");
            DropTable("dbo.Addresses");
            DropTable("dbo.Companies");
            DropTable("dbo.Calenders");
            DropTable("dbo.Bookings");
            DropTable("dbo.Activities");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.User");
        }
    }
}
