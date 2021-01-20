using LandingSPA.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LandingSPA.SqlViewModels
{
    public class PricingPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public Guid SubscriptionId { get; set; }

        public decimal Price { get; set; }

        public SubscriptionDuration SubscriptionDuration { get; set; }

        [ForeignKey("SubscriptionId")]
        public virtual Subscription Subscription { get; set; }
    }
}