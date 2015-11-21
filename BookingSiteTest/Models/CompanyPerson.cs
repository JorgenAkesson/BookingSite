using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSiteTest.Models
{
    public class CompanyPerson
    {
        public virtual Person Person { get; set; }
        public virtual Company Company { get; set; }
    }
}