using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Vender
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string? surname { get; set; }
        public string? patronymic { get; set; }
        public string? БИК { get; set; }
        public string? Расчетный_счет { get; set; }
        public string? КПП { get; set; }
        public string? ОГРНИП { get; set; }
        public string? Adress { get; set; }
        public string? Форма_регистрации { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
