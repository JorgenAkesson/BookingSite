﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Models;

namespace MvcApplication4.Models
{
    public class ActivitiesModel
    {
        public int PersonId { get; set; }
        public int CopanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Activity> Activities { get; set; }
    }
}