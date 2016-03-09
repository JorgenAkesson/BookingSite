using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace BookingSiteTest.Models.ViewModels
{
    public class ActivityBooking
    {
        public Activity Activity { get; set; }
        public Customer Customer { get; set; }
        public string Note { get; set; }
    }
}