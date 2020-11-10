using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class Book
    {
        public Book()
        {
            BookDetail = new HashSet<BookDetail>();
        }

        public int BId { get; set; }
        public int? CId { get; set; }
        public int? BQuantity { get; set; }
        public double? BPriceTotal { get; set; }
        public DateTime? BDate { get; set; }

        public virtual Customer C { get; set; }
        public virtual ICollection<BookDetail> BookDetail { get; set; }
    }
}
