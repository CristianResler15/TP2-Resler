using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Catalogo_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        public Articulo Articulo { get; set; }
        List<Articulo> ListaArticulos = new List<Articulo>();
        Carro carro = new Carro();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            try
            {
                carro = (Carro)Session[Session.SessionID + "articulo"];
                if (carro != null)
                {
                    dgvCarrito.DataSource = carro.Productos;
                    dgvCarrito.DataBind();
                }
                    //if (carro.ContadorArticulo > 0 )
                    //{
                    //    dgvCarrito.HeaderRow.CssClass = "text-danger";
                    //}
            }
            catch (Exception)
            {


            }
        }
        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvCarrito.Rows[index].Cells[1].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            if (carro.Productos.Exists(A => A.Id == idSeleccionado))
            {
                Articulo = carro.Productos.Find(J => J.Id == idSeleccionado);
                carro.Productos.Remove(Articulo);
                Session.Add(Session.SessionID + "articulo", carro);
                Response.Redirect("Carrito.aspx");

            }
        }
    }
}