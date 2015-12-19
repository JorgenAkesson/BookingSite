namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Activity", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "Time", c => c.String());
            AlterColumn("dbo.Activity", "Name", c => c.String());
        }
    }
}
