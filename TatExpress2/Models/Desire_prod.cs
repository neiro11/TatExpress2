using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Desire_prod
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public int id_desire { get; set; }
        public int id_prod { get; set; }
        
    }
}
