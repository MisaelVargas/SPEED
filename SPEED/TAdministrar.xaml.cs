using System;
using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class TAdministrar : Page
    {
        private readonly Search search;

        public TAdministrar()
        {
            InitializeComponent();

            search = new Search();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            Wait.Visibility = Visibility.Visible;
            MEspera.Content = "Buscando...";

            if (SearchValue.Text?.Length == 0)
            {
                MessageBox.Show("Ingrese datos de busqueda");
            }
            else
            {
                TrabajadoresGrid.ItemsSource = search.Trabajadores(SearchValue.Text).DefaultView;
            }

            Wait.Visibility = Visibility.Hidden;
        }

        private void TrabajadoresGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TrabajadoresGrid.SelectedIndex >= 0)
            {
                MainWindow mW = (MainWindow)Application.Current.Windows[0];
                Trabajadores t = (Trabajadores)mW.Pestañas.Content;
                t.Cursor.Margin = new Thickness(0, 0, 0, 0);
                t.PGrid.Content = new TAñadir(Int32.Parse(Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 0)),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 1),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 2),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 3),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 4),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 9),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 5),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 8),
                                              Int32.Parse(Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 6)),
                                              Int32.Parse(Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 7)),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 10),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 11),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 12),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 13),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 14),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 15),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 16),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 17),
                                              Cell.GetCellValue(TrabajadoresGrid, TrabajadoresGrid.SelectedIndex, 18));
            }
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy-MM-dd";
        }
    }
}
