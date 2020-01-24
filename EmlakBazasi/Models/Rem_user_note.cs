using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Rem_user_note
    {
        public int id_rem_user_note { get; set; }
        public Nullable<int> fk_id_rem_user { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> note_date { get; set; }
        public string IP { get; set; }
        public string note { get; set; }
        public Nullable<int> is_deleted { get; set; }
    }
}