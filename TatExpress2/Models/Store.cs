using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Store
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public int id_vender { get; set; }
        public string? Logo { get; set; }
        public string Description { get; set; }
    }
}
