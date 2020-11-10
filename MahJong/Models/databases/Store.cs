using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class Store
    {
        public Store()
        {
            AdminStore = new HashSet<AdminStore>();
            Table = new HashSet<Table>();
        }

        public string SId { get; set; }
        public string SName { get; set; }
        public string STel { get; set; }
        public TimeSpan? SOpenTime { get; set; }
        public TimeSpan? SCloseTime { get; set; }
        public string SAddress { get; set; }
        public string SDistrict { get; set; }
        public string SProvince { get; set; }
        public string SLatitude { get; set; }
        public string SLongitude { get; set; }

        public virtual ICollection<AdminStore> AdminStore { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}
