using MySql.Data.MySqlClient;
using SPEED.MySql;

namespace SPEED
{
    internal class Delete
    {
        private readonly MySQL mysql;

        public Delete()
        {
            mysql = new MySQL();
        }

        public void Pasajero(int idPersona)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeletePasajeros(" + idPersona + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public void Trabajador(int idPersona)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeleteTrabajadores(" + idPersona + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public void Proveedor(int idProveedor)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeleteProveedores(" + idProveedor + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public void Ruta(int idRuta)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeleteRutas (" + idRuta + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public void Dispositivo(int idInventario)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeleteDispositivo (" + idInventario + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }

        public void Camion(int idInventario)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CALL DeleteCamion (" + idInventario + ");", mysql.Connection);
                cmd.ExecuteNonQuery();

                mysql.CloseConnection();
            }
        }
    }
}
