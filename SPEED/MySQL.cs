using MySql.Data.MySqlClient;
using System.Windows;

namespace SPEED.MySql
{
    public class MySQL
    {
        public MySQL()
        {
            Initialize();
        }

        //Representa la conexion con la base de datos
        public MySqlConnection Connection { get; private set; }

        private void Initialize()
        {
            //server = "85.10.205.173";
            //Parametros de la conexion con la base de datos
            const string connectionString = "SERVER=localhost;" +
                                            "DATABASE=transportes;" +
                                            "PORT=3307;" +
                                            "UID=root;" +
                                            "PASSWORD=misael1590;" +
                                            "SSLMODE=none;";

            Connection = new MySqlConnection(connectionString);
        }

        //Abre la conexión con la base de datos
        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Conexion con el servidor no establecida
                //1045: Usuario y/o password no valido(s)
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("no se puede conectar al servidor. contacta al administrador");
                        break;

                    case 1045:
                        MessageBox.Show("usuario y/o password al servidor invalido(s), intenta de nuevo");
                        break;
                }
                return false;
            }
        }

        //Cierra la conexión con la base de datos
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}