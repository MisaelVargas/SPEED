using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace SPEED
{
    public partial class Añadir : Page
    {
        private readonly AddOrEdit insertupdate;
        private readonly Delete delete;
        private string fechaEx;
        private string fechaVe;
        private int idpersona;
        private int idtarjeta;

        public Añadir()
        {
            InitializeComponent();

            idpersona = 0;
            Borrar.IsEnabled = false;
            insertupdate = new AddOrEdit();
        }

        public Añadir(int _idpersona,
                      int _idtarjeta,
                      string Nombre,
                      string ApPat,
                      string ApMat,
                      string edad,
                      string genero,
                      string curp,
                      string tsangre,
                      int dOrganos,
                      int dSangre,
                      string telefono,
                      string ocupacion,
                      string numtarjeta,
                      string cnombre,
                      string ctelefono,
                      string fechaexpedicion,
                      string fechavencimiento)
        {
            InitializeComponent();

            idpersona = _idpersona;
            idtarjeta = _idtarjeta;
            fechaEx = fechaexpedicion;
            fechaVe = fechavencimiento;
            delete = new Delete();
            Borrar.IsEnabled = true;
            AgregarActualiz.Content = "Actualizar";
            insertupdate = new AddOrEdit();

            FillData(Nombre,
                     ApPat,
                     ApMat,
                     edad,
                     genero,
                     curp,
                     tsangre,
                     dOrganos,
                     dSangre,
                     telefono,
                     ocupacion,
                     numtarjeta,
                     cnombre,
                     ctelefono);
        }

        private void Foto_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Captura exitosa");

            Foto.Source = new BitmapImage(new Uri("pack://application:,,,/Art/passportphoto.jpg"));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataAvailable())
            {
                DateTime fecha = DateTime.Now;
                AgregarActualiz.Content = "Agregar";
                string genero = "";
                int venc = 12;

                if (insertupdate.GetNumTarjeta(idtarjeta) != Int64.Parse(Tarjeta.Text))
                {
                    fechaEx = fecha.ToString("yyyy-M-d");
                    fechaVe = fecha.AddMonths(venc).ToString("yyyy-M-d");
                }

                if (Ocupacion.Text == "Estudiante")
                    venc = 6;

                if ((bool)Masculino.IsChecked)
                    genero = Masculino.Content.ToString();
                else
                    genero = Femenino.Content.ToString();

                insertupdate.Pasajero(idpersona,
                                      Nombre.Text,
                                      PApellido.Text,
                                      SApellido.Text,
                                      Int32.Parse(Edad.Text),
                                      Curp.Text,
                                      (bool)DOrganos.IsChecked,
                                      (bool)DSangre.IsChecked,
                                      TSangre.Text,
                                      genero,
                                      Telefono.Text,
                                      Ocupacion.Text,
                                      CTelefono.Text,
                                      CNombre.Text,
                                      Int32.Parse(Tarjeta.Text),
                                      fechaEx,
                                      fechaVe);
                CleanData();
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            AgregarActualiz.Content = "Agregar";

            if (IsDataAvailable())
            {
                delete.Pasajero(idpersona);

                CleanData();
                idpersona = 0;
                Borrar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillData(string _Nombre,
                              string _ApPat,
                              string _ApMat,
                              string _edad,
                              string _genero,
                              string _curp,
                              string _tsangre,
                              int _dOrganos,
                              int _dSangre,
                              string _telefono,
                              string _ocupacion,
                              string _numtarjeta,
                              string _cnombre,
                              string _ctelefono)
        {
            Nombre.Text = _Nombre;
            PApellido.Text = _ApPat;
            SApellido.Text = _ApMat;
            Edad.Text = _edad;
            Curp.Text = _curp;
            TSangre.Text = _tsangre;
            Telefono.Text = _telefono;
            Ocupacion.Text = _ocupacion;
            Tarjeta.Text = _numtarjeta;
            CNombre.Text = _cnombre;
            CTelefono.Text = _ctelefono;

            if (Convert.ToBoolean(_dOrganos))
                DOrganos.IsChecked = true;

            if (Convert.ToBoolean(_dSangre))
                DSangre.IsChecked = true;

            if (_genero == "Masculino")
                Masculino.IsChecked = true;
            else
                Femenino.IsChecked = true;
        }

        private bool IsDataAvailable()
        {
            if    (Nombre.Text?.Length == 0
                || PApellido.Text?.Length == 0
                || SApellido.Text?.Length == 0
                || Edad.Text?.Length == 0
                || Curp.Text?.Length == 0
                || TSangre.Text?.Length == 0
                || Telefono.Text?.Length == 0
                || Ocupacion.Text?.Length == 0
                || CTelefono.Text?.Length == 0
                || CNombre.Text?.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void CleanData()
        {
            Nombre.Text = "";
            PApellido.Text = "";
            SApellido.Text = "";
            Edad.Text = "";
            Curp.Text = "";
            TSangre.Text = "";
            Telefono.Text = "";
            Ocupacion.Text = "";
            CTelefono.Text = "";
            CNombre.Text = "";
            DOrganos.IsChecked = false;
            DSangre.IsChecked = false;
            Foto.Source = new BitmapImage(new Uri("pack://application:,,,/Art/blankimage.jpg"));
        }
    }
}