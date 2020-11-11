using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MahJong.Models.databases
{
    public partial class Customer
    {
        public Customer()
        {
            Book = new HashSet<Book>();
        }

        public int CId { get; set; }
        [DisplayName("ชื่อ")]
        public string CFname { get; set; }
        [DisplayName("นามสกุล")]
        public string CLname { get; set; }
        [DisplayName("วันเกิด")]
        public DateTime? CBirthdate { get; set; }
        [DisplayName("เบอร์โทร")]
        public string CTel { get; set; }
        [DisplayName("Username")]
        public string CUsername { get; set; }
        [DisplayName("Password")]
        public string CPassword { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
