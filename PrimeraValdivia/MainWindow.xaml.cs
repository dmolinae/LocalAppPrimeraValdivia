﻿using System;
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
            DataContext = new MainWindowViewModel();
        }
        /*
        private async void button_crearBD_Click(object sender, RoutedEventArgs e)
        {
            ProgressDialogController dialog = await this.ShowProgressAsync("Por favor espera...", "Creando base de datos");
            dialog.SetIndeterminate();
            await Task.Run(() =>
            {
                Utils.crearBD();
            });
            await dialog.CloseAsync();
            MessageDialogResult async_message = await this.ShowMessageAsync("Exito!", "La base de datos ha sido creada exitosamente.");
        }
        */
    }
}