namespace LandingSPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderColumnOnSubscriptionTypesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubscriptionTypes", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubscriptionTypes", "Type");
        }
    }
}
