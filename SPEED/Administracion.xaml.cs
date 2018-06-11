using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class Administracion : UserControl
    {
        public Administracion()
        {
            InitializeComponent();

            PGrid.Content = new AProveedores();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            Cursor.Margin = new Thickness(159 * index, 0, 0, 0);

            switch (index)
            {
                case 0:
                    PGrid.Content = new AProveedores();
                    break;
                case 1:
                    PGrid.Content = new AMantenimiento();
                    break;
                case 2:
                    PGrid.Content = new AInventario();
                    break;
            }
        }
    }
}
