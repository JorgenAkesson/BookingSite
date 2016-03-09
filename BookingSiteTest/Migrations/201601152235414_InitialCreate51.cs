namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Bookings", name: "Customer_Id", newName: "CustomerId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            CreateIndex("dbo.Bookings", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            RenameColumn(table: "dbo.Bookings", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Bookings", "Customer_Id");
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
