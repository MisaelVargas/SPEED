using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;

namespace SPEED
{
    public partial class TRutas : Page
    {
        private readonly AddOrEdit add;
        private readonly Search search;
        private readonly Delete delete;
        private int idRuta;

        public TRutas()
        {
            InitializeComponent();

            add = new AddOrEdit();
            search = new Search();
            delete = new Delete();
            Borrar.IsEnabled = false;
            idRuta = 0;
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text?.Length == 0)
            {
                MessageBox.Show("Ingrese datos de busqueda");
            }
            else
            {
                RutasGrid.ItemsSource = search.Rutas(SearchBox.Text).DefaultView;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                add.Ruta(idRuta,
                            Nombre.Text,
                            KM.Text,
                            PrecioG.Text,
                            PrecioD.Text);
                CleanData();
                idRuta = 0;
                SearchBox.Text = "";
                Agregar.Content = "Agrega";
                Borrar.IsEnabled = false;
                RutasGrid.Columns.Clear();
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
                delete.Ruta(idRuta);

                CleanData();
                idRuta = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                RutasGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RutasGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RutasGrid.SelectedIndex >= 0)
            {
                Borrar.IsEnabled = true;
                Agregar.Content = "Actualizar";

                idRuta = Int32.Parse(Cell.GetCellValue(RutasGrid, RutasGrid.SelectedIndex, 0));
                Nombre.Text = Cell.GetCellValue(RutasGrid, RutasGrid.SelectedIndex, 1);
                KM.Text = Cell.GetCellValue(RutasGrid, RutasGrid.SelectedIndex, 2);
                PrecioG.Text = Cell.GetCellValue(RutasGrid, RutasGrid.SelectedIndex, 4);
                PrecioD.Text = Cell.GetCellValue(RutasGrid, RutasGrid.SelectedIndex, 5);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsDataAvailable()
            {
                if (Nombre.Text?.Length == 0
                    || KM.Text?.Length == 0
                    || PrecioG.Text?.Length == 0
                    || PrecioD.Text?.Length == 0)
                {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            Nombre.Text = "";
            KM.Text = "";
            PrecioG.Text = "";
            PrecioD.Text = "";
        }
    }
}
