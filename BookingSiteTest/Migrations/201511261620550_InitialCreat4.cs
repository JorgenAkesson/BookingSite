namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreat4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Booking", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Booking", new[] { "UserId" });
            DropTable("dbo.UserProfile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfile",
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
            
            CreateIndex("dbo.Booking", "UserId");
            AddForeignKey("dbo.Booking", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
        }
    }
}
