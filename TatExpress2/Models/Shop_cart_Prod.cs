using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Shop_cart_Prod
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int id_shop_cart { get; set; }
        public int id_prod { get; set; }
        public int count { get; set; }
    }
}
