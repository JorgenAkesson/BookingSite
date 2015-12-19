using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSiteTest.Models
{
    public class Activity
    {
        public Activity()
        {
            this.Bookings = new HashSet<Booking>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Namn måste anges!")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Datum måste anges!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Antal personer måste anges!")]
        public int MaxPerson { get; set; }
        [Required(ErrorMessage = "Längd måste anges!")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Start tid måste anges!")]
        [RegularExpression(@"([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Änge tid på HH:MM")]
        public string Time { get; set; }
        public int CalenderId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Calender Calender { get; set; }
    }
}