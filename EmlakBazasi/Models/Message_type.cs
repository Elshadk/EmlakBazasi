using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Message_type
    {
        public int id_message_type { get; set; }
        public string message_code { get; set; }
        public string message_description { get; set; }
    }
}