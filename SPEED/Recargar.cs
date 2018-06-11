using MySql.Data.MySqlClient;
using SPEED.MySql;
using System;

namespace SPEED
{
    class Recargar
    {
        private readonly MySQL mysql;

        public Recargar()
        {
            mysql = new MySQL();
        }

        public void Tarjeta(string idTarjeta, string monto)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL Recargas (" + idTarjeta + ", " + monto +");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public bool IsNumTarjeta(int NumTarjeta)
        {
            bool numtarjeta = false;

            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT IsNumTarjeta(" + NumTarjeta + ");", mysql.Connection);

                numtarjeta = Convert.ToBoolean(cmd.ExecuteScalar());

                mysql.CloseConnection();

                return numtarjeta;
            }
            return numtarjeta;
        }
    }
}
