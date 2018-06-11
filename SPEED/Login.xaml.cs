using System;
using System.Windows;
using SPEED.MySql;

namespace SPEED
{
    public partial class SQLLogin : Window
    {
        private readonly Login login;

        public SQLLogin()
        {
            InitializeComponent();

            //WarningMessage();

            login = new Login();
        }

        private void WarningMessage()
        {
            string mensaje = "Este programa NO a sido sometido a las pruebas necesarias," + Environment.NewLine +
                                   "es posible que EL CONSUMO DE MEMORIA SEA ALTO." + Environment.NewLine +
                                   "¿Desea continuar ejecutando el programa?";
            const string titulo = "Advertencia";

            var resultado = MessageBox.Show(mensaje, titulo, MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //MySQL mySQL = new MySQL();
            //mySQL.OpenConnection();
            if (true)//login.IsRegistered(user.Text, password.Password.ToString()))
            {
                MainWindow win2 = new MainWindow(user.Text);
                win2.Show();
                this.Close();
            }
        }
    }
}
