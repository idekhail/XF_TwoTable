using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XF_Mid2_Lab1
{
    public class Person1
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AId { get; set; }        
    }
}
