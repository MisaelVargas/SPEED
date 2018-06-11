using System.Windows;
using System.Windows.Controls;

namespace SPEED
{
    public partial class MainWindow : Window
    {
        public MainWindow(string user)
        {
            InitializeComponent();

            Pestañas.Content = new Recargas();

            //Usuario(user);
        }

        /*private void Usuario(string user)
        {
            Letra.Text = user[0].ToString(); ;
            Nombre.Text = user;
        }*/

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            const string message = "¿Está seguro de cerrar el programa?";
            const string caption = "Cerrar";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question,
                                         MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void CSesion_Click(object sender, RoutedEventArgs e)
        {
            const string message = "¿Está seguro de cerrar sesión?";
            const string caption = "Cerrar sesion";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question,
                                         MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                SQLLogin win1 = new SQLLogin();
                win1.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            MenuCursor.Margin = new Thickness(0, 39 * index, 0, 0);

            switch (index)
            {
                case 0:
                    Pestañas.Content = new Recargas();
                    break;
                case 1:
                    Pestañas.Content = new Pasajeros();
                    break;
                case 2:
                    Pestañas.Content = new Transporte();
                    break;
                case 3:
                    Pestañas.Content = new Administracion();
                    break;
                case 4:
                    Pestañas.Content = new Trabajadores();
                    break;
            }
        }
    }
}