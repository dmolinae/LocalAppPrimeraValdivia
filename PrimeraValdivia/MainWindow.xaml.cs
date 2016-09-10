using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PrimeraValdivia.ViewModels;

namespace PrimeraValdivia
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CompaniaViewModel();
            
        }
        private async void button_crearBD_Click(object sender, RoutedEventArgs e)
        {
            ProgressDialogController dialog = await this.ShowProgressAsync("Por favor espera...", "Creando base de datos");
            dialog.SetIndeterminate();
            await Task.Run(() =>
            {
                crearBD();
            });
            await dialog.CloseAsync();
            MessageDialogResult async_message = await this.ShowMessageAsync("Exito!", "La base de datos ha sido creada exitosamente.");
        }
        public void crearBD()
        {
            string script = File.ReadAllText(getMainPath() + @"\dataBase_sqlite.sql");
            SQLiteConnection conn = new SQLiteConnection("Data Source=bomberos.db");
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = script;
            command.ExecuteNonQuery();
            conn.Close();
        }
        private string getMainPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string actualPath = Directory.GetParent(path).FullName;
            string binPath = Directory.GetParent(actualPath).FullName;
            string mainPath = Directory.GetParent(binPath).FullName;
            return mainPath;
        }
    }
}