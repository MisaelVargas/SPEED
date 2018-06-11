using MySql.Data.MySqlClient;
using System.Data;
using SPEED.MySql;
using System.Windows;

namespace SPEED
{
    internal class Login
    {
        private readonly MySQL connect;

        public Login()
        {
            connect = new MySQL();
        }

        public bool IsRegistered(string user, string pass)
        {
            if (connect.OpenConnection())
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM trabajadores WHERE usuario = '" + user + "'" + " and contraseña = '" + pass + "'";

                    MySqlDataAdapter returnVal = new MySqlDataAdapter(query, connect.Connection);

                    DataTable data = new DataTable();

                    returnVal.Fill(data);

                    if (data.Rows[0][0].ToString() == "1")
                        return true;
                }
                finally
                {
                    MessageBox.Show("Ususario y/o contraseña incorrectos");
                }
                return false;
            }
            return false;
        }
    }
}
