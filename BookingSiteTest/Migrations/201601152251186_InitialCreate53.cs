namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate53 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            AlterColumn("dbo.Bookings", "CustomerId", c => c.Int());
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id");
            CreateIndex("dbo.Bookings", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            AlterColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "CustomerId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
