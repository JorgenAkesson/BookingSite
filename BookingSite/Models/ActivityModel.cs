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
        [Required(ErrorMessage = "Title is required.")]
        public object Name;


    }

}