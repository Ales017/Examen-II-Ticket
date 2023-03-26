using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class ServicioDB
    {
        string cadena = "server=localhost; user=root; database=ticket; password=Alejandro017;";



        public DataTable DevolverServicio()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM servicio ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return dt;
        }



        public Servicio DevolverServicioPorCodigo(string codigo)
        {
            Servicio servicio = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM servicio WHERE Codigo = @Codigo; ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 80).Value = codigo;
                        MySqlDataReader dr = comando.ExecuteReader();
                        if (dr.Read())
                        {
                            servicio = new Servicio();
                            servicio.Codigo = codigo;
                            servicio.Descripcion = dr["Descripcion"].ToString();
                            servicio.Precio = Convert.ToDecimal(dr["Precio"]);
                            servicio.cantidad = Convert.ToDecimal(dr["Cantidad"]);
                            servicio.total = Convert.ToDecimal(dr["Total"]);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return servicio;
        }

        public DataTable DevolverServicioPorDescripcion(string descripcion)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM servicio WHERE Descripcion LIKE '%" + descripcion + "%'");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return dt;
        }
    }
}
