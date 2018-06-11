using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    /// <summary>
    /// Lógica de interacción para Pasajeros.xaml
    /// </summary>
    public partial class Pasajeros : UserControl
    {
        public Pasajeros()
        {
            InitializeComponent();

            PGrid.Content = new Añadir();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            Cursor.Margin = new Thickness(143 * index, 0, 0, 0);

            switch (index)
            {
                case 0:
                    PGrid.Content = new Añadir();
                    break;
                case 1:
                    PGrid.Content = new PAdministrar();
                    break;
            }
        }
    }
}
