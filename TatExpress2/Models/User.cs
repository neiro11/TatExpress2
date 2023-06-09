﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatExpress2.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; }
        public string Password { get; set; }
    }
}
