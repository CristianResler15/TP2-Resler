using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> Listado = new List<Categoria>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-8NPLU65\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from Categorias";

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria aux3 = new Categoria();
                    aux3.Id = lector.GetInt32(0);
                    aux3.Descripcion = lector.GetString(1);



                    Listado.Add(aux3);
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