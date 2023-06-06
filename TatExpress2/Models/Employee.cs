using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
        public string Registartion_address { get; set; }
        public string? Role { get; set; }
        public string Password { get; set; }
    }
}
