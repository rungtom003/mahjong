using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahJong.Models.db.table
{
    public class Table
    {
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_row { get; set; }
        public string t_column { get; set; }
        public float t_price { get; set; }
        public string s_id { get; set; }
    }
}
