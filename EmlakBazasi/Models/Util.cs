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
        public string trTextColor { get; set; }
        public string trFontStyle { get; set; }
        public string trBgColor { get; set; }
        public int rowCount { get; set; }
        public int rowGeneral { get; set; }


    }
}