using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSiteTest.Models
{
    public class City
    {
        public City()
        {
            this.Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}