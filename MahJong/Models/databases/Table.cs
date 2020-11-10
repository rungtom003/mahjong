using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class Table
    {
        public Table()
        {
            BookDetail = new HashSet<BookDetail>();
        }

        public int TId { get; set; }
        public string TName { get; set; }
        public string TRow { get; set; }
        public string TColumn { get; set; }
        public double? TPrice { get; set; }
        public string SId { get; set; }

        public virtual Store S { get; set; }
        public virtual ICollection<BookDetail> BookDetail { get; set; }
    }
}
