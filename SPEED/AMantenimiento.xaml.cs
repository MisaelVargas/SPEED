using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPEED
{
    public partial class AMantenimiento : Page
    {
        private readonly AddOrEdit add;
        private readonly Search search;

        public AMantenimiento()
        {
            InitializeComponent();

            add = new AddOrEdit();
            search = new Search();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fi = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(FechaInicio.Text));
                string ft = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(FechaTermino.Text));

                if (IsDataAvailable())
                {
                    add.Mantenimiento(Int32.Parse(IdInventario.Text), fi, ft);

                    CleanData();
                }
                else
                {
                    MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Ingrese los datos nuevamente," + Environment.NewLine +
                                "Verifique que el id sea valido" + Environment.NewLine +
                                "y las fechas esten en el formato correcto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text?.Length == 0)
            {
                MessageBox.Show("Ingrese datos de busqueda");
            }
            else
            {
                MantenimientoGrid.ItemsSource = search.Proveedores(SearchBox.Text).DefaultView;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public bool IsDataAvailable()
        {
            if (IdInventario.Text?.Length == 0
                || FechaInicio.Text?.Length == 0
                || FechaTermino.Text?.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            IdInventario.Text = "";
            FechaInicio.Text = "";
            FechaTermino.Text = "";
        }
    }
}
