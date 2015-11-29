namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "Address_Id", "dbo.Address");
            DropIndex("dbo.Company", new[] { "Address_Id" });
            RenameColumn(table: "dbo.Company", name: "Address_Id", newName: "AddressId");
            AddForeignKey("dbo.Company", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
            CreateIndex("dbo.Company", "AddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "AddressId" });
            DropForeignKey("dbo.Company", "AddressId", "dbo.Address");
            RenameColumn(table: "dbo.Company", name: "AddressId", newName: "Address_Id");
            CreateIndex("dbo.Company", "Address_Id");
            AddForeignKey("dbo.Company", "Address_Id", "dbo.Address", "Id");
        }
    }
}
