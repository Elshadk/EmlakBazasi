using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class All_user_note
    {
        public int id_rem_user_note { get; set; }
        public Nullable<System.DateTime> note_date { get; set; }
        public string full_name { get; set; }
        public string office_name { get; set; }
        public string phone_number { get; set; }
        public string note { get; set; }
    }
}