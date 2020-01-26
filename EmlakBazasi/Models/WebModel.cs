using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class WebModel
    {
        public List<View_rem_user> view_rem_user_list { get; set; }
        public List<Rem_user_type> user_type_list { get; set; }
        public List<Message_type> message_list { get; set; }
        public int user { get; set; }
    }
}