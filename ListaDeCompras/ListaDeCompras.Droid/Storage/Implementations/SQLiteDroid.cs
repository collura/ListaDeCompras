using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using ListaDeCompras;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace ListaDeCompras
{
    public class SQLiteDroid:ISQLite
    {
        public SQLiteDroid() {
        }

        public SQLiteConnection GetConnection() { 
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            //create connection
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }    
    }
}