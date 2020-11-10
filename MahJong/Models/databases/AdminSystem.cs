using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class AdminSystem
    {
        public int AId { get; set; }
        public string AUsername { get; set; }
        public string APassword { get; set; }
        public string AName { get; set; }
        public string ALname { get; set; }
        public string ATel { get; set; }
        public string RastId { get; set; }

        public virtual RightAdminSystem Rast { get; set; }
    }
}
