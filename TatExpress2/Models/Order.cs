using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Order
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public int? Status_id { get; set; }
        public string Date_create { get; set; }
        public string? Date_get { get; set; }
        public int? User_id { get; set; }
        public int? Empleyee_id { get; set; }
        public int? Price { get; set; }
        public int? Count { get; set; }
    }
}
