using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.RESTApi.Models
{
    public class ActivityManager : IActivityManager
    {
        public List<Activity> GetActivties(int? page, int? count)
        {
            return new List<Activity>(){new Activity(){Date = DateTime.Now, Description = "Test", Id = 1, MaxPerson = 3, Name = "Hoppa", TotalPerson = 2}};
        }
    }
}