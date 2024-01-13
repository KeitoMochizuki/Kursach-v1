using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Курсач
{
    public class User
    {
        private readonly SQLiteConnection con;

        public User(string path)
        {
            con = new SQLiteConnection(path);
            con.CreateTable<Info>();
        }
        public int SavePair(Info pair)
        {
            return con.Insert(pair);
        }
        public Info GetUserByName(string u)
        {
            Info inf = con.Table<Info>().FirstOrDefault(x => x.Username == u);
            return inf;
        }
        public bool CheckUser(string u)
        {
            Info inf = con.Table<Info>().FirstOrDefault(x => x.Username == u);
            if (inf == null)
                return true;
            return false;
        }
    }
}
