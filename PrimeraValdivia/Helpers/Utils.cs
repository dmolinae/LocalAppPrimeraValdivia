using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Helpers
{
    public class Utils
    {
        private SQLiteConnection conn;
        private SQLiteCommand command;
        private SQLiteDataAdapter da;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public void crearBD()
        {
            string script = File.ReadAllText(getMainPath() + @"\dataBase_sqlite.sql");
            SetConnection();
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = script;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void cargarBD()
        {
            string script = File.ReadAllText(getMainPath() + @"\datosBomberos.sql");
            SetConnection();
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = script;
            command.ExecuteNonQuery();
            conn.Close();
        }

        public string getMainPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string actualPath = Directory.GetParent(path).FullName;
            string binPath = Directory.GetParent(actualPath).FullName;
            string mainPath = Directory.GetParent(binPath).FullName;
            return mainPath;
        }

        private void SetConnection()
        {
            conn = new SQLiteConnection("Data Source=bomberos.db");
        }
        public void ExecuteNonQuery(string txtQuery)
        {
            SetConnection();
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = txtQuery;
            Debug.Write(txtQuery);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable ExecuteQuery(string txtQuery)
        {
            ds = new DataSet();
            dt = new DataTable();
            SetConnection();
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = txtQuery;
            try
            {
                da = new SQLiteDataAdapter(command);
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch { }
            conn.Close();
            return dt;
        }

        public string DateSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day);
        }
    }
}
