using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSiteTest.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int? UserId { get; set; }
        public string Note { get; set; }
        public int? CustomerId { get; set; }

        public virtual Activity Activity { get; set; }
        [Obsolete]
        public virtual UserProfile User { get; set; }
        public virtual Customer Customer { get; set; }
    }
}