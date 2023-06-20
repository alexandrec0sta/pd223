using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRest.Models
{
    public class TLE
    {
        public string id { get; set; }
        public string type { get; set; }
        public int satelliteId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
    }
}