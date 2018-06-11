using System;
using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class PAdministrar : Page
    {
        private readonly Search search;

        public PAdministrar()
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
                PasajerosGrid.ItemsSource = search.Pasajeros(SearchValue.Text).DefaultView;
                PasajerosGrid.Columns[1].Visibility = Visibility.Hidden;
            }
            Wait.Visibility = Visibility.Hidden;
        }

        private void PasajerosGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PasajerosGrid.SelectedIndex >= 0)
            {
                MainWindow mW = (MainWindow)Application.Current.Windows[0];
                Pasajeros p = (Pasajeros)mW.Pestañas.Content;
                p.Cursor.Margin = new Thickness(0, 0, 0, 0);
                p.PGrid.Content = new Añadir(Int32.Parse(Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 0)),
                                             Int32.Parse(Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 2)),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 3),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 4),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 5),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 6),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 13),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 7),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 12),
                                             Int32.Parse(Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 10)),
                                             Int32.Parse(Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 11)),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 9),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 8),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 16),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 14),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 15),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 17),
                                             Cell.GetCellValue(PasajerosGrid, PasajerosGrid.SelectedIndex, 18));
            }
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy-MM-dd";
        }
    }
}
