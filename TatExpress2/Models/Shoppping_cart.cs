using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Shoppping_cart
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int User_id { get; set; }
    }
}
