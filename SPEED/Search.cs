using MySql.Data.MySqlClient;
using System.Data;
using SPEED.MySql;

namespace SPEED
{
    internal class Search
    {
        private readonly MySQL mysql;

        public Search()
        {
            mysql = new MySQL();
        }

        public DataTable Pasajeros(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Pasajeros", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }

        public DataTable Trabajadores(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Trabajadores", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }

        public DataTable Proveedores(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Proveedores", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }

        public DataTable Inventario(string searchValue) 
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Inventario", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);
                mysql.CloseConnection();
                return table;
            }
            return null;
        }

        public DataTable Rutas(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Rutas", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }

        public DataTable Dispositivos(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Dispositivo", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }

        public DataTable Camiones(string searchValue)
        {
            if (mysql.OpenConnection())
            {
                MySqlDataAdapter data = new MySqlDataAdapter("Search_Camiones", mysql.Connection);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("_SearchValue", searchValue);
                DataTable table = new DataTable();
                data.Fill(table);

                mysql.CloseConnection();

                return table;
            }
            return null;
        }
    }
}
