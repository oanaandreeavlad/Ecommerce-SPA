using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingSPA.Models
{
    public class SubscriptionTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
    }
}