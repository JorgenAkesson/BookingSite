namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "Customer_Id", c => c.Int());
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers", "Id");
            CreateIndex("dbo.Bookings", "Customer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropColumn("dbo.Bookings", "Customer_Id");
            DropTable("dbo.Customers");
        }
    }
}
