using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class AdminStore
    {
        public int AsId { get; set; }
        public string AsUsername { get; set; }
        public string AsPassword { get; set; }
        public string AsName { get; set; }
        public string AsLname { get; set; }
        public string AsTel { get; set; }
        public string RasId { get; set; }
        public string SId { get; set; }

        public virtual RightAdminStore Ras { get; set; }
        public virtual Store S { get; set; }
    }
}
