using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;

namespace BookingSiteTest.Models
{
    public class Events
    {
        public string id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }
        public string color { get; set; }
        public bool allDay { get; set; }
        public bool fullyBooked { get; set; }
        public bool description { get; set; }
    }
}