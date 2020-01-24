using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Rem_user_reminder
    {
        public int id_rem_user_reminder { get; set; }
        public Nullable<int> fk_id_rem_user { get; set; }
        public Nullable<System.DateTime> reminder_date { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string note { get; set; }
        public string IP { get; set; }
        public Nullable<int> is_deleted { get; set; }
    }
}