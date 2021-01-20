namespace LandingSPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubscriptionTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriptionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageSource = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscriptionTypes");
        }
    }
}
