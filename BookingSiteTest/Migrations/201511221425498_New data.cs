namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newdata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "Calender_Id", "dbo.Calender");
            DropForeignKey("dbo.Booking", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Calender", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.CompanyPerson", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.CompanyPerson", "Company_Id", "dbo.Company");
            DropIndex("dbo.Activity", new[] { "Calender_Id" });
            DropIndex("dbo.Booking", new[] { "ActivityId" });
            DropIndex("dbo.Calender", new[] { "Company_Id" });
            DropIndex("dbo.CompanyPerson", new[] { "Person_Id" });
            DropIndex("dbo.CompanyPerson", new[] { "Company_Id" });
            RenameColumn(table: "dbo.Activity", name: "Calender_Id", newName: "CalenderId");
            RenameColumn(table: "dbo.Calender", name: "Company_Id", newName: "CompanyID");
            RenameColumn(table: "dbo.CompanyPerson", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.CompanyPerson", name: "Company_Id", newName: "CompanyId");
            AlterColumn("dbo.Booking", "ActivityId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Activity", "CalenderId", "dbo.Calender", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Booking", "ActivityId", "dbo.Activity", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Calender", "CompanyID", "dbo.Company", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyPerson", "PersonId", "dbo.Person", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyPerson", "CompanyId", "dbo.Company", "Id", cascadeDelete: true);
            CreateIndex("dbo.Activity", "CalenderId");
            CreateIndex("dbo.Booking", "ActivityId");
            CreateIndex("dbo.Calender", "CompanyID");
            CreateIndex("dbo.CompanyPerson", "PersonId");
            CreateIndex("dbo.CompanyPerson", "CompanyId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompanyPerson", new[] { "CompanyId" });
            DropIndex("dbo.CompanyPerson", new[] { "PersonId" });
            DropIndex("dbo.Calender", new[] { "CompanyID" });
            DropIndex("dbo.Booking", new[] { "ActivityId" });
            DropIndex("dbo.Activity", new[] { "CalenderId" });
            DropForeignKey("dbo.CompanyPerson", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyPerson", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Calender", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Booking", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Activity", "CalenderId", "dbo.Calender");
            AlterColumn("dbo.Booking", "ActivityId", c => c.Int());
            RenameColumn(table: "dbo.CompanyPerson", name: "CompanyId", newName: "Company_Id");
            RenameColumn(table: "dbo.CompanyPerson", name: "PersonId", newName: "Person_Id");
            RenameColumn(table: "dbo.Calender", name: "CompanyID", newName: "Company_Id");
            RenameColumn(table: "dbo.Activity", name: "CalenderId", newName: "Calender_Id");
            CreateIndex("dbo.CompanyPerson", "Company_Id");
            CreateIndex("dbo.CompanyPerson", "Person_Id");
            CreateIndex("dbo.Calender", "Company_Id");
            CreateIndex("dbo.Booking", "ActivityId");
            CreateIndex("dbo.Activity", "Calender_Id");
            AddForeignKey("dbo.CompanyPerson", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.CompanyPerson", "Person_Id", "dbo.Person", "Id");
            AddForeignKey("dbo.Calender", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Booking", "ActivityId", "dbo.Activity", "Id");
            AddForeignKey("dbo.Activity", "Calender_Id", "dbo.Calender", "Id");
        }
    }
}
