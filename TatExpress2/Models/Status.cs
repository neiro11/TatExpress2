using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Status
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
