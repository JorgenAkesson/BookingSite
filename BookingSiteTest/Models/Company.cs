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
            this.Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> AdministratorPersonId { get; set; }
        public bool HasAdministrator { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
        public virtual Person Person { get; set; }
    }
}