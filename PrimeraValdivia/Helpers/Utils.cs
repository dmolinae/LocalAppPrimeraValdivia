using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace PrimeraValdivia.ViewModels
{
    public class Utils
    {
        public static void crearBD()
        {
            string script = File.ReadAllText(getMainPath() + @"\dataBase_sqlite.sql");
            SQLiteConnection conn = new SQLiteConnection("Data Source=bomberos.db");
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = script;
            command.ExecuteNonQuery();
            conn.Close();
        }
        private static string getMainPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string actualPath = Directory.GetParent(path).FullName;
            string binPath = Directory.GetParent(actualPath).FullName;
            string mainPath = Directory.GetParent(binPath).FullName;
            return mainPath;
        }
    }
}
