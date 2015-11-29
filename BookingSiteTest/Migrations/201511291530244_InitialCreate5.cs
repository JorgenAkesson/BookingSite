namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        PostalNumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "Email", c => c.String());
            AddColumn("dbo.Company", "Phone", c => c.String());
            AddColumn("dbo.Company", "WebPage", c => c.String());
            AddColumn("dbo.Company", "Description", c => c.String());
            AddColumn("dbo.Company", "Logotype_Id", c => c.Int());
            AddColumn("dbo.Company", "CompanyImage_Id", c => c.Int());
            AddColumn("dbo.Company", "Address_Id", c => c.Int());
            AddForeignKey("dbo.Company", "Logotype_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Company", "CompanyImage_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Company", "Address_Id", "dbo.Address", "Id");
            CreateIndex("dbo.Company", "Logotype_Id");
            CreateIndex("dbo.Company", "CompanyImage_Id");
            CreateIndex("dbo.Company", "Address_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "Address_Id" });
            DropIndex("dbo.Company", new[] { "CompanyImage_Id" });
            DropIndex("dbo.Company", new[] { "Logotype_Id" });
            DropForeignKey("dbo.Company", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Company", "CompanyImage_Id", "dbo.Images");
            DropForeignKey("dbo.Company", "Logotype_Id", "dbo.Images");
            DropColumn("dbo.Company", "Address_Id");
            DropColumn("dbo.Company", "CompanyImage_Id");
            DropColumn("dbo.Company", "Logotype_Id");
            DropColumn("dbo.Company", "Description");
            DropColumn("dbo.Company", "WebPage");
            DropColumn("dbo.Company", "Phone");
            DropColumn("dbo.Company", "Email");
            DropTable("dbo.Address");
            DropTable("dbo.Images");
        }
    }
}
