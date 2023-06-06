using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Prod_order
    {
        [AutoIncrement,PrimaryKey]
        public int id { get; set; }
        public int id_prod { get; set; }
        public int id_order { get; set; }
        public int Count { get; set; }
       
    }
}
