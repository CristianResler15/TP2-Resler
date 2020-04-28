using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dominio
{
    public class Articulo
    {
        
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImagenURL { get; set; }
        public decimal Precio { get; set; }

        public void Agregar(Articulo nuevo)
        {
            
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-8NPLU65\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Articulos (Nombre,Codigo,Descripcion,Precio,ImagenURL,IdMarca, Idcategoria) values (@Nombre,@Codigo,@Descripcion,@Precio,@ImagenURL,@IdMarca,@IdCategoria)";
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("IdMarca", nuevo.Marca.Id);
                comando.Parameters.AddWithValue("@Idcategoria", nuevo.Categoria.Id);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            
        }
    }
}
