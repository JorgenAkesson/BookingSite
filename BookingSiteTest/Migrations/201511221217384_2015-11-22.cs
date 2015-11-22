namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20151122 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "CompanyId", "dbo.Company");
            DropIndex("dbo.Activity", new[] { "CompanyId" });
            DropColumn("dbo.Activity", "CompanyId");
            DropColumn("dbo.Activity", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activity", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Activity", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activity", "CompanyId");
            AddForeignKey("dbo.Activity", "CompanyId", "dbo.Company", "Id", cascadeDelete: true);
        }
    }
}
