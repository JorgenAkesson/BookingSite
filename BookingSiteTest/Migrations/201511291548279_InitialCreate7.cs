namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "AddressId", "dbo.Address");
            DropIndex("dbo.Company", new[] { "AddressId" });
            AlterColumn("dbo.Company", "AddressId", c => c.Int());
            AddForeignKey("dbo.Company", "AddressId", "dbo.Address", "Id");
            CreateIndex("dbo.Company", "AddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "AddressId" });
            DropForeignKey("dbo.Company", "AddressId", "dbo.Address");
            AlterColumn("dbo.Company", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Company", "AddressId");
            AddForeignKey("dbo.Company", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
        }
    }
}
