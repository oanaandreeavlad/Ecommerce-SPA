namespace LandingSPA.Migrations
{
    using LandingSPA.SqlViewModels;
    using LandingSPA.ValueObjects;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LandingSPA.Models.LandingSPAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LandingSPA.Models.LandingSPAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            #region Subscription Types
            context.SubscriptionTypes.AddOrUpdate(
                p => p.Name,
                new SubscriptionTypes
                {
                    Id = Guid.NewGuid(),
                    Type = SubscriptionType.Individual,
                    Name = SubscriptionType.Individual.ToString("g"),
                    Description = "Tea plants, organic supplements",
                    ImageSource = "https://images.unsplash.com/photo-1599989687563-8d28144a3cc4?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
                },
                 new SubscriptionTypes
                 {
                     Id = Guid.NewGuid(),
                     Type = SubscriptionType.Home,
                     Name = SubscriptionType.Home.ToString("g"),
                     Description = "Aromatic spices, micro garden for fresh cooking herbs, tea plants, organic supplements",
                     ImageSource = "https://images.unsplash.com/photo-1492778297155-7be4c83960c7?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=1350&q=80"
                 }, 
                 new SubscriptionTypes
                 {
                     Id = Guid.NewGuid(),
                     Type = SubscriptionType.Corporate,
                     Name = SubscriptionType.Corporate.ToString("g"),
                     Description = "Indoor and outdoor plants, tea and organic beverages plants",
                     ImageSource = "https://images.unsplash.com/photo-1511554623205-71faeb82db3c?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=1350&q=80"
                 }
                );

            #endregion

            #region Subscriptions
            context.Subscriptions.AddOrUpdate(
              p => p.Id,
              new Subscription 
              { 
                  Id = new Guid("2b525c23-ca30-4cbe-ab92-483159b8de3e"), 
                  Name = "You & Tea", 
                  Description = "Large selection of herbal tea plants combined with flowers, fruits and seeds at your choise.", 
                  SubscriptionType = ValueObjects.SubscriptionType.Individual  
              },
              new Subscription
              {
                    Id = new Guid("f133095a-fa24-4dc3-b04f-2a9085ad7e39"),
                    Name = "Herbal Health",
                    Description = "Natural supplements brewed in-house from therapeutic herbs, according to your needs.",
                    SubscriptionType = ValueObjects.SubscriptionType.Individual
              },
              new Subscription 
              { 
                  Id = new Guid("964b2ccf-2872-4532-8ef7-a6637b9951d7"), 
                  Name = "Nature's Cook", 
                  Description = "Aromatic spices from herbs grown in Planteria's greenhouse, carefully air-dried and wrapped in biodegradable  packages.", 
                  SubscriptionType = ValueObjects.SubscriptionType.Home  
              },
              new Subscription
                  {
                      Id = new Guid("e74445cb-b246-4432-8486-c8ae35b604e5"),
                      Name = "Micro Garden",
                      Description = "Grow your own cooking herbs in a kitchen micro garden with everything you need: from basil, cilantro,  to greek oregano, french sorrel and mint.",
                      SubscriptionType = ValueObjects.SubscriptionType.Home
                  },
              new Subscription
                 {
                     Id = new Guid("a208b057-0976-4dbd-b831-977a74b5341f"),
                     Name = "Wellness",
                     Description = "Planteria's widest selection of tea plants, air-dried fruits and flowers mixes and in-house brewed supplements for you and your loved ones.",
                     SubscriptionType = ValueObjects.SubscriptionType.Home
                 },
                new Subscription
                {
                    Id = new Guid("daddc5a7-08b0-4dba-929a-5abc769920c7"),
                    Name = "Home Complete",
                    Description = "Customize all Home subscriptions according to your needs and get the best experience.",
                    SubscriptionType = ValueObjects.SubscriptionType.Home
                },

              new Subscription 
              { 
                  Id = new Guid("fdd55166-a9a4-4f21-8d86-b93d1938b3a6"),
                  Name = "Urban Garden", 
                  Description = "Bring nature closer into your workspace with stunning indoor and outdoor decor plants.", 
                  SubscriptionType = ValueObjects.SubscriptionType.Corporate 
              },

              new Subscription 
              { 
                  Id = new Guid("f870be42-e1c2-421f-9a07-3fcf89944d63"),
                  Name = "Tea Break", 
                  Description = "Planteria's widest selection of tea mixes and freshly home brewed beverages.", 
                  SubscriptionType = ValueObjects.SubscriptionType.Corporate 
              },
               new Subscription
               {
                   Id = new Guid("37d4627e-7fed-417e-8859-a177cbe31775"),
                   Name = "Planteria Corporate",
                   Description = "Get the full experience of greenery and leisure drinks into your office.",
                   SubscriptionType = ValueObjects.SubscriptionType.Corporate
               }
            );

            #endregion

            #region Pricing Plans
            context.PricingPlans.AddOrUpdate(
                p => p.Id,
                new PricingPlan 
                { 
                    Id = new Guid("b8a68f5a-47ef-4d79-acbc-d1c4cfe89b76"), 
                    SubscriptionDuration = ValueObjects.SubscriptionDuration._6Months, 
                    Price = 30, 
                    SubscriptionId = new Guid("2b525c23-ca30-4cbe-ab92-483159b8de3e") 
                },
                new PricingPlan 
                { 
                    Id = new Guid("37e48e21-23dd-4c69-9c52-f789dd084318"), 
                    SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual, 
                    Price = 55, 
                    SubscriptionId = new Guid("f133095a-fa24-4dc3-b04f-2a9085ad7e39") 
                },
                new PricingPlan 
                { 
                    Id = new Guid("c91caa33-5c8a-42b6-b6f5-587fdd28b0ee"), 
                    SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual, 
                    Price = 45, 
                    SubscriptionId = new Guid("964b2ccf-2872-4532-8ef7-a6637b9951d7") 
                },
                  new PricingPlan
                  {
                      Id = new Guid("e2141db6-9e46-44f7-819f-0f43953a7b8e"),
                      SubscriptionDuration = ValueObjects.SubscriptionDuration._3Months,
                      Price = 80,
                      SubscriptionId = new Guid("e74445cb-b246-4432-8486-c8ae35b604e5")
                  },

                  new PricingPlan
                  {
                      Id = new Guid("1ea4049a-527f-4c3a-85be-07d661411df9"),
                      SubscriptionDuration = ValueObjects.SubscriptionDuration._6Months,
                      Price = 50,
                      SubscriptionId = new Guid("a208b057-0976-4dbd-b831-977a74b5341f")
                  },
                  new PricingPlan
                  {
                      Id = new Guid("e595c54c-2d7f-48a2-a69c-e6a3a1a2d820"),
                      SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual,
                      Price = 120,
                      SubscriptionId = new Guid("daddc5a7-08b0-4dba-929a-5abc769920c7")
                  },
                       new PricingPlan
                       {
                           Id = new Guid("7b65e29b-8815-486d-bb83-104faf84fcd2"),
                           SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual,
                           Price = 250,
                           SubscriptionId = new Guid("fdd55166-a9a4-4f21-8d86-b93d1938b3a6")
                       },
                       new PricingPlan
                       {
                           Id = new Guid("e054f2b1-952a-42b9-9f3a-5ba6d4edf39a"),
                           SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual,
                           Price = 300,
                           SubscriptionId = new Guid("f870be42-e1c2-421f-9a07-3fcf89944d63")
                       },
                       new PricingPlan
                       {
                           Id = new Guid("7eb775e9-72b8-4ad4-b1e2-24a00add33a6"),
                           SubscriptionDuration = ValueObjects.SubscriptionDuration.Annual,
                           Price = 520,
                           SubscriptionId = new Guid("37d4627e-7fed-417e-8859-a177cbe31775")
                       }
            );

            #endregion
        }
    }
}
