using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class Trabajadores : UserControl
    {
        public Trabajadores()
        {
            InitializeComponent();

            PGrid.Content = new TAñadir();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            Cursor.Margin = new Thickness(143 * index, 0, 0, 0);

            switch (index)
            {
                case 0:
                    PGrid.Content = new TAñadir();
                    break;
                case 1:
                    PGrid.Content = new TAdministrar();
                    break;
            }
        }
    }
}