using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MahJong.Models.databases
{
    public partial class AdminStore
    {     
        public int AsId { get; set; }
        [DisplayName("Username")]
        public string AsUsername { get; set; }
        [DisplayName("Password")]
        public string AsPassword { get; set; }
        [DisplayName("ชื่อ")]
        public string AsName { get; set; }
        [DisplayName("นามสกุล")]
        public string AsLname { get; set; }
        [DisplayName("เบอร์โทร")]
        public string AsTel { get; set; }
        [DisplayName("สิทธิ์การเข้าถึง")]
        public string RasId { get; set; }
        [DisplayName("ID ร้าน")]
        public string SId { get; set; }

        public virtual RightAdminStore Ras { get; set; }
        public virtual Store S { get; set; }
    }
}
