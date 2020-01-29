using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Rem_user_payment
    {
        public int id_user_payment { get; set; }
        public Nullable<int> fk_id_rem_user { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public int sum { get; set; }
        public string note { get; set; }
        public string IP { get; set; }
        public Nullable<int> id_deleted { get; set; }
    }
}