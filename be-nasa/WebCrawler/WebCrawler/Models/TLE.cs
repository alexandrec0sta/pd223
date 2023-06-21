using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Models
{
    public class TLE
    {
        public class TLEData
        {
            public string context { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public int totalItems { get; set; }
            public Member[] member { get; set; }
            public Parameters parameters { get; set; }
            public View view { get; set; }
        }

        public class Parameters
        {
            public string search { get; set; }
            public string sort { get; set; }
            public string sortdir { get; set; }
            public int page { get; set; }
            public int pagesize { get; set; }
        }

        public class View
        {
            public string id { get; set; }
            public string type { get; set; }
            public string first { get; set; }
            public string next { get; set; }
            public string last { get; set; }
        }

        public class Member
        {
            [JsonProperty("@id")]
            public string id { get; set; }

            [JsonProperty("@type")]
            public string type { get; set; }

            [JsonProperty("satelliteId")]
            public int satelliteId { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("date")]
            public DateTime date { get; set; }

            [JsonProperty("line1")]
            public string line1 { get; set; }

            [JsonProperty("line2")]
            public string line2 { get; set; }
        }
    }
}
