//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public Activity()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public int MaxPerson { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        public string Time { get; set; }
        public int CityId { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual Company Company { get; set; }
        public virtual City City { get; set; }
    }
}
