using System;
using System.Collections.Generic;

namespace MahJong.Models.databases
{
    public partial class Customer
    {
        public Customer()
        {
            Book = new HashSet<Book>();
        }

        public int CId { get; set; }
        public string CFname { get; set; }
        public string CLname { get; set; }
        public DateTime? CBirthdate { get; set; }
        public string CTel { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
