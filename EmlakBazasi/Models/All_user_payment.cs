using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class All_user_payment
    {
        public int id_user_payment { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public int sum { get; set; }
        public string full_name { get; set; }
        public string office_name { get; set; }
        public string phone_number { get; set; }
        public string note { get; set; }
    }
}