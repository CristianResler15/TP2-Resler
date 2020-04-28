using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            List<Marca> Listado = new List<Marca>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                
                conexion.ConnectionString = "data source=DESKTOP-8NPLU65\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from Marcas";

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Marca aux2 = new Marca();
                    aux2.Id = lector.GetInt32(0);
                    aux2.Descripcion = lector.GetString(1);



                    Listado.Add(aux2);
                }


                return Listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
