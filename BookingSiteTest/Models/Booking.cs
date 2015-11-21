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
        public Nullable<int> ActivityId { get; set; }
        public int PersonId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Person Person { get; set; }
    }
}