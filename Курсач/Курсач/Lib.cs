using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Курсач
{
    public class Lib
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string ENG { get; set; }
        public string RUS { get; set; }
    }
}
