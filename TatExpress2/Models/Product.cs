using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Product
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Count { get; set; }
        public string Description { get; set; }
        public string? Mass { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string Photo { get; set; }
        public int? Store_id { get; set; }
    }
}
