using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class PP_owner
    {
        [AutoIncrement,PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string БИК { get; set; }
        public string КПП { get; set; }
        public string Расчетный_счет { get; set; }
        public string ОГРНИП { get; set; }
        public string Форма_регистрации { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
