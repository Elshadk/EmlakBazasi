using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Util
    {
        public int last_request_period { get; set; }
        public string status { get; set; }
        public string reminderColor { get; set; }
        public string readingStatusLastDate { get; set; }
        public int readingStatusHours { get; set; }
        public string readingStatusVersion { get; set; }

        public string subscriberColor { get; set; }
        public string tagColor { get; set; }

    }
}