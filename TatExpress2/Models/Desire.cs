using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Desire
    {
        [AutoIncrement, PrimaryKey]
        public int id { get; set; }
        public int User_id { get; set; }

    }
}
