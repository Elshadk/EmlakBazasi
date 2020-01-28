using System;

namespace EmlakBazasi.Models
{
    public class Rem_user
    {
        public int id_rem_user { get; set; }
        public Nullable<int> user { get; set; }
        public string office_name { get; set; }
        public string full_name { get; set; }
        public string reference { get; set; }
        public string MAC { get; set; }
        public Nullable<int> service_price { get; set; }
        public string phone_number { get; set; }
        public string phone_number_ex { get; set; }
        public string email_address { get; set; }
        public System.DateTime start_date { get; set; }
        public int reading_data_count { get; set; }
        public Nullable<int> fk_id_rem_user_type { get; set; }
        public Nullable<int> believe { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> fk_id_message_type { get; set; }
        public string last_IP { get; set; }
        public Nullable<System.DateTime> last_request_date { get; set; }
        public Nullable<int> last_request_result { get; set; }
        public string version { get; set; }
        public string note { get; set; }
        public Nullable<int> subscriber_tag { get; set; }
        public Nullable<int> tag { get; set; }
        public Nullable<int> is_deleted { get; set; }
        public Nullable<int> additional_client { get; set; }

    }
}