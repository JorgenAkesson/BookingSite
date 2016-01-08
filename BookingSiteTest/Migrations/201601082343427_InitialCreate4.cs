namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Provider = c.String(),
                        ProviderUserId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.webpages_OAuthMembership");
        }
    }
}
