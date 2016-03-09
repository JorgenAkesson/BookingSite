namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate52 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.User");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            AlterColumn("dbo.Bookings", "UserId", c => c.Int());
            AddForeignKey("dbo.Bookings", "UserId", "dbo.User", "UserId");
            CreateIndex("dbo.Bookings", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropForeignKey("dbo.Bookings", "UserId", "dbo.User");
            AlterColumn("dbo.Bookings", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
