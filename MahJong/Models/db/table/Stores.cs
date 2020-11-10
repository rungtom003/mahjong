using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahJong.Models.db.table
{
    public class Stores
    {
        public string s_id { get; set; }
        public string s_name { get; set; }
        public string s_tel { get; set; }
        public TimeSpan s_open_time { get; set; }
        public TimeSpan s_close_time { get; set; }
        public string s_address { get; set; }
        public string s_district { get; set; }
        public string s_province { get; set; }
        public string s_latitude { get; set; }
        public string s_longitude { get; set; }
        
    }
}
