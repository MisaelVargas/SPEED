using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPEED
{
    public partial class TCamiones : Page
    {
        private readonly AddOrEdit add;
        private readonly Search search;
        private readonly Delete delete;
        private int idInventario;

        public TCamiones()
        {
            InitializeComponent();

            add = new AddOrEdit();
            search = new Search();
            delete = new Delete();
            Borrar.IsEnabled = false;
            idInventario = 0;
        }

        private void Buscar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SearchBox.Text?.Length == 0)
            {
                MessageBox.Show("Ingrese datos de busqueda");
            }
            else
            {
                CamionesGrid.ItemsSource = search.Camiones(SearchBox.Text).DefaultView;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                add.Camion(idInventario,
                            idDispositivo.Text,
                            idRuta.Text,
                            NumeroCamion.Text,
                            NumeroInventario.Text,
                            Marca.Text,
                            Modelo.Text,
                            Estado.Text);
                CleanData();
                idInventario = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                CamionesGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                delete.Camion(idInventario);

                CleanData();
                idInventario = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                CamionesGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CamionesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CamionesGrid.SelectedIndex >= 0)
            {
                Borrar.IsEnabled = true;
                Agregar.Content = "Actualizar";

                idInventario = Int32.Parse(Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 3));
                idDispositivo.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 1);
                idRuta.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 2);
                NumeroCamion.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 4);
                NumeroInventario.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 5);
                Marca.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 6);
                Modelo.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 7);
                Estado.Text = Cell.GetCellValue(CamionesGrid, CamionesGrid.SelectedIndex, 8);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsDataAvailable()
        {
            if (NumeroInventario.Text?.Length == 0
                || idDispositivo.Text?.Length == 0
                || idRuta.Text?.Length == 0
                || NumeroCamion.Text?.Length == 0
                || Marca.Text?.Length == 0
                || Modelo.Text?.Length == 0
                || Estado.Text?.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            idDispositivo.Text = "";
            idRuta.Text = "";
            NumeroCamion.Text = "";
            NumeroInventario.Text = "";
            Marca.Text = "";
            Modelo.Text = "";
        }
    }
}
