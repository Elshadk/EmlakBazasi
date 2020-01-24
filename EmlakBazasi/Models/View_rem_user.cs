using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class View_rem_user
    {
        public int id_user { get; set; }
        public Nullable<int> fk_id_rem_user_type { get; set; }
        public string user_type_name { get; set; }
        public Nullable<int> user { get; set; }
        public string office_name { get; set; }
        public string full_name { get; set; }
        public Nullable<int> service_price { get; set; }
        public string phone_number { get; set; }
        public string phone_number_ex { get; set; }
        public string email_address { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> is_deleted { get; set; }
        public Nullable<int> tag { get; set; }
        public Nullable<int> subscriber_tag { get; set; }
        public Nullable<System.DateTime> last_request_date { get; set; }
        public string version { get; set; }
        public Nullable<int> last_request_result { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public Nullable<System.DateTime> reminder_date { get; set; }
        public string reminder_note { get; set; }
    }
}