namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.webpages_Membership", "PasswordVerificationTokenExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.webpages_Membership", "PasswordVerificationTokenExpirationDate", c => c.DateTime(nullable: false));
        }
    }
}
