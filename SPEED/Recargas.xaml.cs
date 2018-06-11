using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPEED
{
    public partial class Recargas : Page
    {
        private readonly Recargar recargar;

        public Recargas()
        {
            InitializeComponent();

            recargar = new Recargar();
        }

        private void Recarga_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (recargar.IsNumTarjeta(Int32.Parse(NumTarjeta.Text)))
            {
                if (IsDataAvailable())
                {
                    recargar.Tarjeta(NumTarjeta.Text, Monto.Text);

                    CleanData();
                }
                else
                {
                    MessageBox.Show("Faltan datos");
                }
            }
            else
            {
                MessageBox.Show("Numero de tarjeta incorrecto");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsDataAvailable()
        {
            if (NumTarjeta.Text?.Length == 0
                || Monto.Text?.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            NumTarjeta.Text = "";
            Monto.Text = "";
        }
    }
}
