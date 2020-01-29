using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class View_source_status
    {
        public int id_source { get; set; }
        public string source_name { get; set; }
        public DateTime last_reading_date { get; set; }
        public string last_read_property_type { get; set; }
    }
}