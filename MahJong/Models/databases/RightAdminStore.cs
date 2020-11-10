using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class RightAdminStore
    {
        public RightAdminStore()
        {
            AdminStore = new HashSet<AdminStore>();
        }

        public string RasId { get; set; }
        public string RasName { get; set; }
        public string RasDetail { get; set; }

        public virtual ICollection<AdminStore> AdminStore { get; set; }
    }
}
