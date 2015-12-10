using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using BookingSiteTest.Views.Calender;

namespace BookingSiteTest.Models
{
    public class Company
    {
        public Company()
        {
            this.Calenders = new HashSet<Calender>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebPage { get; set; }
        public string Description { get; set; }
        public int? AddressId { get; set; }
        public int? LogotypeImageId { get; set; }
        public int? CompanyId { get; set; }

        public virtual ICollection<Calender> Calenders { get; set; }
        public virtual Address Address { get; set; }
        public virtual Images LogotypeImage { get; set; }
        public virtual Images CompanyImage { get; set; }
    }
}