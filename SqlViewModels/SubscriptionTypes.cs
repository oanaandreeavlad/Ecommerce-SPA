using LandingSPA.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LandingSPA.SqlViewModels
{
    public class SubscriptionTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        public SubscriptionType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageSource { get; set; }
    }
}