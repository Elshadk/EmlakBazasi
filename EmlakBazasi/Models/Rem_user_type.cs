using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakBazasi.Models
{
    public class Rem_user_type
    {
        public int id_rem_user_type { get; set; }
        public string type_name { get; set; }
        public Nullable<int> status { get; set; }
    }
}