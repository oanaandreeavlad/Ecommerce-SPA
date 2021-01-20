using LandingSPA.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LandingSPA.SqlViewModels
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SubscriptionType SubscriptionType { get; set; }

        [InverseProperty("Subscription")]
        public virtual IList<PricingPlan> PricingPlans { get; set; }
    }
}