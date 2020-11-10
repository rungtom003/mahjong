﻿using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class BookDetail
    {
        public int BdId { get; set; }
        public int? BId { get; set; }
        public int? TId { get; set; }

        public virtual Book B { get; set; }
        public virtual Table T { get; set; }
    }
}
