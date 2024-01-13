using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System.Reflection;

namespace Курсач
{
    public partial class App : Application
    {
        /*
        private static DataBase db;
        public static DataBase Db
        {
            get
            {
                if (db == null)
                    db = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.sqlite3"));
                return db;
            }
        }
        */

        private static User us;
        public static User Us
        {
            get
            {
                if (us == null)
                    us = new User(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.sqlite3"));
                return us;
            }
        }

        public const string DATABASE_NAME = "Lib.db";
        public static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"Курсач.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new Database(dbPath);
                }
                return database;
            }
        }
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TabbedPage1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
