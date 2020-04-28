using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
   public class AccesoDatos
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }
    public  AccesoDatos()
    {
        conexion = new SqlConnection("data source=DESKTOP-8NPLU65\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=sspi");
        comando = new SqlCommand();
        comando.Connection = conexion;
    }
        public void setearQuery( string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;

        }
       
        public void EjeutarLector()
        {

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //conexion.Close();
            }

        }
            public void CerrarConexion()
            {
                conexion.Close();
            }

        internal void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        internal void ejecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }

}
