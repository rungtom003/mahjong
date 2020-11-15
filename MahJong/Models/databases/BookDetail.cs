using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class BookDetail
    {
        public int BdId { get; set; }
        public string BId { get; set; }
        public int? TId { get; set; }
        public string BdStatus { get; set; }

        public virtual Book B { get; set; }
        public virtual Table T { get; set; }
    }
}
