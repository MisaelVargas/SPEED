using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace SPEED
{
    public partial class AProveedores : Page
    {
        private readonly AddOrEdit add;
        private readonly Search search;
        private readonly Delete delete;
        private int idProveedor;

        public AProveedores()
        {
            InitializeComponent();

            add = new AddOrEdit();
            search = new Search();
            delete = new Delete();
            Borrar.IsEnabled = false;
            idProveedor = 0;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                add.Proveedor(idProveedor,
                            Rfc.Text,
                            RazonSocial.Text,
                            Calle.Text,
                            Orientacion.Text,
                            NumeroExt.Text,
                            NumeroInt.Text,
                            Colonia.Text,
                            Ciudad.Text,
                            Estado.Text,
                            CodigoPostal.Text,
                            Recurso.Text);
                CleanData();
                idProveedor = 0;
                SearchBox.Text = "";
                Borrar.IsEnabled = false;
                Agregar.Content = "Agrega";
                ProveedoresGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                ProveedoresGrid.ItemsSource = search.Proveedores(SearchBox.Text).DefaultView;
            }
        }

        private void ProveedoresGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ProveedoresGrid.SelectedIndex >= 0)
            {
                Borrar.IsEnabled = true;
                Agregar.Content = "Actualizar";

                idProveedor = Int32.Parse(Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 0));
                Rfc.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 1);
                RazonSocial.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 2);
                Calle.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 3);
                Orientacion.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 4);
                NumeroExt.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 5);
                NumeroInt.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 6);
                Colonia.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 7);
                Ciudad.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 8);
                Estado.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 9);
                CodigoPostal.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 10);
                Recurso.Text = Cell.GetCellValue(ProveedoresGrid, ProveedoresGrid.SelectedIndex, 11);
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                delete.Proveedor(idProveedor);

                CleanData();
                idProveedor = 0;
                SearchBox.Text = "";
                Agregar.Content = "Agrega";
                Borrar.IsEnabled = false;
                ProveedoresGrid.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsDataAvailable()
        {
            if (RazonSocial.Text?.Length == 0
                || Rfc.Text?.Length == 0
                || Calle.Text?.Length == 0
                || Orientacion.Text?.Length == 0
                || NumeroExt.Text?.Length == 0
                || NumeroInt.Text?.Length == 0
                || Colonia.Text?.Length == 0
                || Ciudad.Text?.Length == 0
                || Estado.Text?.Length == 0
                || CodigoPostal.Text?.Length == 0
                || Recurso.Text?.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            RazonSocial.Text = "";
            Rfc.Text = "";
            Calle.Text = "";
            NumeroExt.Text = "";
            NumeroInt.Text = "";
            Colonia.Text = "";
            Ciudad.Text = "";
            Estado.Text = "";
            CodigoPostal.Text = "";
        }
    }
}
