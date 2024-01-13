using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Курсач
{
    public class Database
    {
        private readonly SQLiteConnection con;

        public Database(string path)
        {
            con = new SQLiteConnection(path);
            con.CreateTable<Lib>();
        }
        public List<Lib> GetPair()
        {
            return con.Table<Lib>().ToList();
        }
        public int SavePair(Lib pair)
        {
            return con.Insert(pair);
        }
        public Lib GetItemById(int itemId)
        {
            Lib lib=con.Table<Lib>().FirstOrDefault(x => x.ID == itemId);
            return lib;
        }
        public Lib GetEng(string e)
        {
            Lib lib = con.Table<Lib>().FirstOrDefault(x => x.ENG == e);
            return lib;
        }
        public Lib GetRus(string r)
        {
            Lib lib = con.Table<Lib>().FirstOrDefault(x => x.RUS == r);
            return lib;
        }
    }
}
 