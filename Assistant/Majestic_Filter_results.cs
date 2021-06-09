using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    public class Majestic_Filter_results
    {
        public List<good_domain> Mfr { get; set; } = new List<good_domain>();
    }

    public class good_domain
    {
        public int Num_id { get; set; }
        public string Ok_domain { get; set; }
        public List<domain_data> Domain_info { get; set; } = new List<domain_data>();
        public string Data_sources { get; set; }
    }

    public class domain_data
    {
        public string good_domain_title { get; set; }
        public string good_domain_url { get; set; }
        public string good_domain_language { get; set; }
    }
}
