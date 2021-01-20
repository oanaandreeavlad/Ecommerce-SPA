using EnumsNET;
using LandingSPA.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingSPA.Models
{
    public class SubscriptionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SubscriptionType SubscriptionType { get; set; }

        public decimal Price { get; set; }

        public SubscriptionDuration SubscriptionDuration { get; set; }

        public string SubscriptionDurationString { 
            get 
            {
                return this.SubscriptionDuration.AsString(EnumFormat.Description);
            } 
        }


    }
}