using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPEED
{
    /// <summary>
    /// Lógica de interacción para TAñadir.xaml
    /// </summary>
    public partial class TAñadir : Page
    {
        private readonly AddOrEdit insertupdate;
        private readonly Delete delete;
        private int idpersona;

        public TAñadir()
        {
            InitializeComponent();

            Borrar.IsEnabled = false;
            insertupdate = new AddOrEdit();
            idpersona = 0;
        }

        public TAñadir(int _idpersona,
                       string nombre,
                       string apPat,
                       string apMat,
                       string edad,
                       string genero,
                       string curp,
                       string tsangre,
                       int dOrganos,
                       int dSangre,
                       string telefono,
                       string rfc,
                       string puesto,
                       string sueldo,
                       string hentrada,
                       string hsalida,
                       string usuario,
                       string contraseña,
                       string nivelacceso)
        {
            InitializeComponent();

            insertupdate = new AddOrEdit();
            delete = new Delete();
            Borrar.IsEnabled = true;
            AgregarActualiz.Content = "Actualizar";
            idpersona = _idpersona;

            FillData(nombre,
                     apPat,
                     apMat,
                     edad,
                     genero,
                     curp,
                     tsangre,
                     dOrganos,
                     dSangre,
                     telefono,
                     rfc,
                     puesto,
                     sueldo,
                     hentrada,
                     hsalida,
                     usuario,
                     contraseña,
                     nivelacceso);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AgregarActualiz.Content = "Agregar";

                if (IsDataAvailable())
                {
                    string genero = "";

                    if ((bool)Masculino.IsChecked)
                        genero = Masculino.Content.ToString();
                    else
                        genero = Femenino.Content.ToString();

                    insertupdate.Trabajador(idpersona,
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
                                          RFC.Text,
                                          Puesto.Text,
                                          Sueldo.Text,
                                          HEntrada.Text,
                                          HSalida.Text,
                                          Usuario.Text,
                                          Contraseña.Password,
                                          Int32.Parse(NivelAcceso.Text));
                    CleanData();
                }
                else
                {
                    MessageBox.Show("Faltan dato(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Formato de hora de entrada y/o de salida incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            AgregarActualiz.Content = "Agregar";

            if (IsDataAvailable())
            {
                delete.Trabajador(idpersona);

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
                              string _rfc,
                              string _puesto,
                              string _sueldo,
                              string _hentrada,
                              string _hsalida,
                              string _usuario,
                              string _contraseña,
                              string _nivelacceso)
        {
            Nombre.Text = _Nombre;
            PApellido.Text = _ApPat;
            SApellido.Text = _ApMat;
            Edad.Text = _edad;
            Curp.Text = _curp;
            TSangre.Text = _tsangre;
            Telefono.Text = _telefono;
            RFC.Text = _rfc;
            Puesto.Text = _puesto;
            Sueldo.Text = _sueldo;
            HEntrada.Text = _hentrada;
            HSalida.Text = _hsalida;
            Usuario.Text = _usuario;
            Contraseña.Password = _contraseña;
            NivelAcceso.Text = _nivelacceso;

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
                || RFC.Text?.Length == 0
                || Puesto.Text?.Length == 0
                || Sueldo.Text?.Length == 0
                || HEntrada.Text?.Length == 0
                || HSalida.Text?.Length == 0
                || Usuario.Text?.Length == 0
                || Contraseña.Password?.Length == 0)
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
            RFC.Text = "";
            Puesto.Text = "";
            Sueldo.Text = "";
            HEntrada.Text = "";
            HSalida.Text = "";
            Usuario.Text = "";
            Contraseña.Password = "";
        }
    }
}
