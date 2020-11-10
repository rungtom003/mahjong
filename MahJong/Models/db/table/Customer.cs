using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahJong.Models.db.table
{
    public class Customer
    {
        public int c_id { get; set; }
        public string c_fname { get; set; }
        public string c_lname { get; set; }
        public DateTime c_birthdate { get; set; }
        public string c_tel { get; set; }
    }
}
