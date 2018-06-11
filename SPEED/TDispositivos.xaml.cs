using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPEED
{
    public partial class TDispositivos : Page
    {
        private readonly AddOrEdit add;
        private readonly Search search;
        private readonly Delete delete;
        private int idInventario;

        public TDispositivos()
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
                DispositivosGrid.ItemsSource = search.Dispositivos(SearchBox.Text).DefaultView;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                add.Dispositivo(idInventario,
                            NumeroInventario.Text,
                            Marca.Text,
                            Modelo.Text,
                            Estado.Text);
                CleanData();
                idInventario = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                DispositivosGrid.Columns.Clear();
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
                delete.Dispositivo(idInventario);

                CleanData();
                idInventario = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                DispositivosGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DispositivosGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DispositivosGrid.SelectedIndex >= 0)
            {
                Borrar.IsEnabled = true;
                Agregar.Content = "Actualizar";

                idInventario = Int32.Parse(Cell.GetCellValue(DispositivosGrid, DispositivosGrid.SelectedIndex, 1));
                NumeroInventario.Text = Cell.GetCellValue(DispositivosGrid, DispositivosGrid.SelectedIndex, 2);
                Marca.Text = Cell.GetCellValue(DispositivosGrid, DispositivosGrid.SelectedIndex, 3);
                Modelo.Text = Cell.GetCellValue(DispositivosGrid, DispositivosGrid.SelectedIndex, 4);
                Estado.Text = Cell.GetCellValue(DispositivosGrid, DispositivosGrid.SelectedIndex, 5);
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
            NumeroInventario.Text = "";
            Marca.Text = "";
            Modelo.Text = "";
        }
    }
}
