using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class Transporte : UserControl
    {
        public Transporte()
        {
            InitializeComponent();

            PGrid.Content = new TCamiones();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            Cursor.Margin = new Thickness(143 * index, 0, 0, 0);

            switch (index)
            {
                case 0:
                    PGrid.Content = new TCamiones();
                    break;
                case 1:
                    PGrid.Content = new TRutas();
                    break;
                case 2:
                    PGrid.Content = new TDispositivos();
                    break;
            }
        }
    }
}
