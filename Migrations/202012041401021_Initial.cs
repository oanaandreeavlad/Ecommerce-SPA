namespace LandingSPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PricingPlans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubscriptionId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubscriptionDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionId, cascadeDelete: true)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        SubscriptionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PricingPlans", "SubscriptionId", "dbo.Subscriptions");
            DropIndex("dbo.PricingPlans", new[] { "SubscriptionId" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.PricingPlans");
        }
    }
}
