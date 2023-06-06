using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class PP_order
    {
        [AutoIncrement,PrimaryKey]
        public int id { get; set; }
        public int id_pp { get; set; }
        public int Order_id { get; set; }
        
    }
}
