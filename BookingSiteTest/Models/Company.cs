using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSiteTest.Models
{
    public class Company
    {
        public Company()
        {
            this.Callenders = new HashSet<Calender>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Calender> Callenders { get; set; }
    }
}