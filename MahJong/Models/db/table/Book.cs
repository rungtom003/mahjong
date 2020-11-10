using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahJong.Models.db.table
{
    public class Book
    {
        public int b_id { get; set; }
        public int c_id { get; set; }
        public int b_quantity { get; set; }
        public float b_priceTotal { get; set; }
        public DateTime b_date { get; set; }
    }
}
