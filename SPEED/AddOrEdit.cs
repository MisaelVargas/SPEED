using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;
using SPEED.MySql;
using System;

namespace SPEED
{
    internal class AddOrEdit
    {
        private readonly MySQL mysql;

        public AddOrEdit()
        {
            mysql = new MySQL();
        }

        //Agrega un nuevo pasajero o Edita uno existente en la base de datos
        public void Pasajero(int Id ,string Nombre,string ApPat , string ApMat,
                                       int Edad, string Curp, bool DonanteOrganos,
                                       bool DonanteSangre, string SangreTipo, string Genero,
                                       string Telefono, string Ocupacion, string TelContacto,
                                       string Contacto, int NumTarjeta, string FechaExpedicion,
                                       string FechaVencimiento)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand data = new MySqlCommand("AddOrEditPasajeros", mysql.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                data.Parameters.AddWithValue("_Id", Id);
                data.Parameters.AddWithValue("_Nombre", Nombre);
                data.Parameters.AddWithValue("_ApPat", ApPat);
                data.Parameters.AddWithValue("_ApMat", ApMat);
                data.Parameters.AddWithValue("_Edad", Edad);
                data.Parameters.AddWithValue("_Curp", Curp);
                data.Parameters.AddWithValue("_DonanteOrganos", DonanteOrganos);
                data.Parameters.AddWithValue("_DonanteSangre", DonanteSangre);
                data.Parameters.AddWithValue("_SangreTipo", SangreTipo);
                data.Parameters.AddWithValue("_Genero", Genero);
                data.Parameters.AddWithValue("_Telefono", Telefono);
                data.Parameters.AddWithValue("_Ocupacion", Ocupacion);
                data.Parameters.AddWithValue("_TelContacto", TelContacto);
                data.Parameters.AddWithValue("_Contacto", Contacto);
                data.Parameters.AddWithValue("_NumTarjeta", NumTarjeta);
                data.Parameters.AddWithValue("_FechaExpedicion", FechaExpedicion);
                data.Parameters.AddWithValue("_FechaVencimiento", FechaVencimiento);
                data.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                mysql.CloseConnection();
            }
        }

        //Agrega un nuevo trabajador o Edita uno existente en la base de datos
        public void Trabajador(int Id, string Nombre, string ApPat, string ApMat,
                                       int Edad, string Curp, bool DonanteOrganos,
                                       bool DonanteSangre, string SangreTipo, string Genero,
                                       string Telefono, string RFC, string Puesto, string Sueldo,
                                       string HoraEntrada, string HoraSalida, string Usuario,
                                       string Contraseña, int NivelAcceso)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand data = new MySqlCommand("AddOrEditTrabajadores", mysql.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                data.Parameters.AddWithValue("_Id", Id);
                data.Parameters.AddWithValue("_Nombre", Nombre);
                data.Parameters.AddWithValue("_ApPat", ApPat);
                data.Parameters.AddWithValue("_ApMat", ApMat);
                data.Parameters.AddWithValue("_Edad", Edad);
                data.Parameters.AddWithValue("_Curp", Curp);
                data.Parameters.AddWithValue("_DonanteOrganos", DonanteOrganos);
                data.Parameters.AddWithValue("_DonanteSangre", DonanteSangre);
                data.Parameters.AddWithValue("_SangreTipo", SangreTipo);
                data.Parameters.AddWithValue("_Genero", Genero);
                data.Parameters.AddWithValue("_Telefono", Telefono);
                data.Parameters.AddWithValue("_RFC", RFC);
                data.Parameters.AddWithValue("_Puesto", Puesto);
                data.Parameters.AddWithValue("_Sueldo", Sueldo);
                data.Parameters.AddWithValue("_HoraEntrada", HoraEntrada);
                data.Parameters.AddWithValue("_HoraSalida", HoraSalida);
                data.Parameters.AddWithValue("_Usuario", Usuario);
                data.Parameters.AddWithValue("_Contraseña", Contraseña);
                data.Parameters.AddWithValue("_NivelAcceso", NivelAcceso);
                data.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                mysql.CloseConnection();
            }
        }

        //Agrega un nuevo Proveedor o Edita uno existente en la base de datos
        public void Proveedor(int Id, string Rfc, string RazonSocial, string Calle,
                                string Orientacion, string NumeroExt, string NumeroInt,
                                string Colonia, string Ciudad, string Estado, string CodigoPostal,
                                string Recurso)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand data = new MySqlCommand("AddOrEditProveedores", mysql.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                data.Parameters.AddWithValue("_Id", Id);
                data.Parameters.AddWithValue("_Rfc", Rfc);
                data.Parameters.AddWithValue("_RazonSocial", RazonSocial);
                data.Parameters.AddWithValue("_Calle", Calle);
                data.Parameters.AddWithValue("_Orientacion", Orientacion);
                data.Parameters.AddWithValue("_NumeroExt", NumeroExt);
                data.Parameters.AddWithValue("_NumeroInt", NumeroInt);
                data.Parameters.AddWithValue("_Colonia", Colonia);
                data.Parameters.AddWithValue("_Ciudad", Ciudad);
                data.Parameters.AddWithValue("_Estado", Estado);
                data.Parameters.AddWithValue("_CodigoPostal", CodigoPostal);
                data.Parameters.AddWithValue("_Recurso", Recurso);
                data.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                mysql.CloseConnection();
            }
        }

        //Agrega los datos del Mantenimiento
        public void Mantenimiento(int idInventario, string FechaInicio, string FechaTermino)
        {
            if (mysql.OpenConnection())
            {
                string query = "INSERT INTO mantenimiento VALUES(0, " + idInventario + ", '" + FechaInicio + "', '" + FechaTermino + "');";
                MySqlCommand cmd = new MySqlCommand(query, mysql.Connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                mysql.CloseConnection();
            }
        }

        //Agrega una nueva RUTA o Edita uno existente en la base de datos
        public void Ruta(int Id, string Nombre, string Extencion_KM,
                         string PrecioGeneral, string PrecioDesc)
        {
            if (mysql.OpenConnection())
            {
                MySqlCommand data = new MySqlCommand("AddOrEditRutas", mysql.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                data.Parameters.AddWithValue("_Id", Id);
                data.Parameters.AddWithValue("_Nombre", Nombre);
                data.Parameters.AddWithValue("_Extencion_KM", Extencion_KM);
                data.Parameters.AddWithValue("_PrecioGeneral", PrecioGeneral);
                data.Parameters.AddWithValue("_PrecioDesc", PrecioDesc);
                data.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                mysql.CloseConnection();
            }
        }

        public void Dispositivo(int Id, string NumInventario, string Marca,
                                string Modelo, string Estado)
        {
            try
            {
                if (mysql.OpenConnection())
                {
                    MySqlCommand data = new MySqlCommand("AddOrEditDispositivo", mysql.Connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    data.Parameters.AddWithValue("_Id", Id);
                    data.Parameters.AddWithValue("_NumInventario", NumInventario);
                    data.Parameters.AddWithValue("_Marca", Marca);
                    data.Parameters.AddWithValue("_Modelo", Modelo);
                    data.Parameters.AddWithValue("_Estado", Estado);
                    data.ExecuteNonQuery();
                    MessageBox.Show("Agregado correctamente");

                    mysql.CloseConnection();
                }
            }
            catch (MySqlException e)
            {
                if (e.Number == 1062)
                    MessageBox.Show("Ya existe un dispositivo con este numero de inventario");

                mysql.CloseConnection();
            }
        }

        public void Camion(int Id, string idDispositivo, string idRuta, string NumeroCamion, 
                             string NumInventario, string Marca, string Modelo, string Estado)
        {
            try
            {
                if (mysql.OpenConnection())
                {
                    MySqlCommand data = new MySqlCommand("AddOrEditCamiones", mysql.Connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    data.Parameters.AddWithValue("_Id", Id);
                    data.Parameters.AddWithValue("_idDispositivo", idDispositivo);
                    data.Parameters.AddWithValue("_idRuta", idRuta);
                    data.Parameters.AddWithValue("_NumeroCamion", NumeroCamion);
                    data.Parameters.AddWithValue("_NumInventario", NumInventario);
                    data.Parameters.AddWithValue("_Marca", Marca);
                    data.Parameters.AddWithValue("_Modelo", Modelo);
                    data.Parameters.AddWithValue("_Estado", Estado);
                    data.ExecuteNonQuery();
                    MessageBox.Show("Agregado correctamente");

                    mysql.CloseConnection();
                }
            }
            catch (MySqlException e)
            {
                if (e.Number == 1062)
                    MessageBox.Show("El ID del dispositivo y/o la ruta no existen");

                mysql.CloseConnection();
            }
        }

        public int GetNumTarjeta(int idtarjeta)
        {
            try
            {
                if (mysql.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT GetNumTarjeta(" + idtarjeta + ");", mysql.Connection);

                    int numtarjeta = Convert.ToInt32(cmd.ExecuteScalar());

                    mysql.CloseConnection();

                    return numtarjeta;
                }
            }
            catch
            {
            }
            return 0;
        }
    }
}
