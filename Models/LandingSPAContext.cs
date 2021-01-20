using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LandingSPA.Models
{
    public class LandingSPAContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LandingSPAContext() : base("name=LandingSPAContext")
        {
        }

        public System.Data.Entity.DbSet<LandingSPA.SqlViewModels.Subscription> Subscriptions { get; set; }
        public System.Data.Entity.DbSet<LandingSPA.SqlViewModels.PricingPlan> PricingPlans { get; set; }
        public System.Data.Entity.DbSet<LandingSPA.SqlViewModels.SubscriptionTypes> SubscriptionTypes { get; set; }
    }
}
