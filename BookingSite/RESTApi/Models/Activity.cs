using System;

namespace MvcApplication4.RESTApi.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int? MaxPerson { get; set; }
        public int? TotalPerson { get; set; }
    }
}