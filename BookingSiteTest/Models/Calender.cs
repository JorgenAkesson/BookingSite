using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSiteTest.Models
{
    public class Calender
    {
        public string Name { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}