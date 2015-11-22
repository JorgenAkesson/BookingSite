using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSiteTest.Models
{
    public class Calender
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }


        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Company Company { get; set; }
    }
}