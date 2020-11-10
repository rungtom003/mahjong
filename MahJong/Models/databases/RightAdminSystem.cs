using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class RightAdminSystem
    {
        public RightAdminSystem()
        {
            AdminSystem = new HashSet<AdminSystem>();
        }

        public string RastId { get; set; }
        public string RastName { get; set; }
        public string RastDetail { get; set; }

        public virtual ICollection<AdminSystem> AdminSystem { get; set; }
    }
}
