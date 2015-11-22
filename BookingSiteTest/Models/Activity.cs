﻿using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public int MaxPerson { get; set; }
        public int Duration { get; set; }
        public string Time { get; set; }
        public int CalenderId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Calender Calender { get; set; }
    }
}