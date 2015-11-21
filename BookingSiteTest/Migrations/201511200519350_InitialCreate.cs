namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        MaxPerson = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Time = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activity", t => t.ActivityId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AdministratorPersonId = c.Int(),
                        HasAdministrator = c.Boolean(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "Person_Id" });
            DropIndex("dbo.Booking", new[] { "PersonId" });
            DropIndex("dbo.Booking", new[] { "ActivityId" });
            DropIndex("dbo.Activity", new[] { "CityId" });
            DropIndex("dbo.Activity", new[] { "CompanyId" });
            DropForeignKey("dbo.Company", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Booking", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Booking", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Activity", "CityId", "dbo.City");
            DropForeignKey("dbo.Activity", "CompanyId", "dbo.Company");
            DropTable("dbo.City");
            DropTable("dbo.Company");
            DropTable("dbo.Person");
            DropTable("dbo.Booking");
            DropTable("dbo.Activity");
        }
    }
}
