using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahJong.Models.databases
{
    public class BookTable
    {
        public int c_id { get; set; }
        public int b_quantity { get; set; }
        public double b_priceTotal { get; set; }
        public DateTime b_date { get; set; }
        public int t_id { get; set; }
    }
}
