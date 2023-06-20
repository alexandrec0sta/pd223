using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRest.Models
{
    public class ROVERS
    {
        public int id { get; set; }
        public int sol { get; set; }
        public int camera_id { get; set; }
        public string camera_name { get; set; }
        public int camerarover_id { get; set; }
        public string camerafull_name { get; set; }
        public string img_src { get; set; }
        public DateTime earth_date { get; set; }
        public int rover_id { get; set; }
        public string rover_name { get; set; }
        public DateTime rover_landing_date { get; set; }
        public DateTime rover_launch_date { get; set; }
        public string rover_status { get; set; }

    }
}