namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Booking", "User_UserId", "dbo.UserProfile");
            DropIndex("dbo.Booking", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Booking", name: "User_UserId", newName: "UserId");
            AddColumn("dbo.CompanyUser", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Booking", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            CreateIndex("dbo.Booking", "UserId");
            DropColumn("dbo.Booking", "PersonId");
            DropColumn("dbo.CompanyUser", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyUser", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.Booking", "PersonId", c => c.Int(nullable: false));
            DropIndex("dbo.Booking", new[] { "UserId" });
            DropForeignKey("dbo.Booking", "UserId", "dbo.UserProfile");
            DropColumn("dbo.CompanyUser", "UserId");
            RenameColumn(table: "dbo.Booking", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.Booking", "User_UserId");
            AddForeignKey("dbo.Booking", "User_UserId", "dbo.UserProfile", "UserId");
        }
    }
}
