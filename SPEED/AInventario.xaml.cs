using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class AInventario : Page
    {
        private readonly Search search;

        public AInventario()
        {
            InitializeComponent();

            search = new Search();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (SearchValue.Text?.Length == 0)
            {
                MessageBox.Show("Ingrese datos de busqueda");
            }
            else
            {
                InventarioGrid.ItemsSource = search.Inventario(SearchValue.Text).DefaultView;
            }
        }
    }
}
