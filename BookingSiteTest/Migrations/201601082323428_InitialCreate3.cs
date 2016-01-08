namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.webpages_Membership", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.webpages_Membership", "LastPasswordFailureDate", c => c.DateTime());
            AlterColumn("dbo.webpages_Membership", "PasswordChangedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.webpages_Membership", "PasswordChangedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.webpages_Membership", "LastPasswordFailureDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.webpages_Membership", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
