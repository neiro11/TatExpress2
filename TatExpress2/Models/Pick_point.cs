using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Pick_point
    {
        [AutoIncrement,PrimaryKey]
        public int id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int id_owner { get; set; }
    }
}
