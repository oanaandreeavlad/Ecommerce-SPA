using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LandingSPA.ValueObjects
{
    public enum SubscriptionDuration
    {
        [Description("Monthly")]
        Monthly = 1,

        [Description("3 Months")]
        _3Months = 2,
        [Description("6 Months")]

        _6Months = 3,
        [Description("Annual")]

        Annual = 4
    }
}