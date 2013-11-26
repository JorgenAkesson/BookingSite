using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcApplication4.Models;

namespace MvcApplication4.Models
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Activity
    {
    }

    public class CustomerMetaData
    {
        [Required(ErrorMessage = "Måste anges!")]
        [Display(Name = "Namn på aktiviteten:")]
        public object Name;

        [Display(Name = "Beskrivning:")]
        public object Description;

        [Required(ErrorMessage = "Måste anges!")]
        [Display(Name = "Datum:")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public object Date;

        [Required(ErrorMessage = "Måste anges!")]
        [Display(Name = "Antal platser:")]
        public object MaxPerson;

        [Required(ErrorMessage = "Måste anges!")]
        [Display(Name = "Varaktighet (minuter):")]
        public object Duration;

        [Required(ErrorMessage = "Måste anges!")]
        [RegularExpression(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Ange på format: HH:mm")]
        [Display(Name = "Start tid:")]
        public object Time;
    }

}