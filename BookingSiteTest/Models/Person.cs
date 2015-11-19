using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSiteTest.Models
{
    public class Person
    {
        public Person()
        {
            this.Booking = new HashSet<Booking>();
            this.Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Company> Company { get; set; }
    }
}