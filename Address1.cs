using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XF_Mid2_Lab1
{
    public class Address1
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string HomeNumber { get; set; }
        public string City { get; set; }
    }
}
