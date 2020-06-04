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
                if (Session[Session.SessionID + "Cantidad"] != null && Session[Session.SessionID + "Total"] != null)
                {
                    LblCarrito.Text = Session[Session.SessionID + "Cantidad"].ToString();
                    LblTotal.Text = LblTotal.Text + Session[Session.SessionID + "Total"].ToString();
                }
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
                carro.ContadorArticulo--;
                carro.AcumuladorPrecio -= Articulo.Precio;
                carro.Productos.Remove(Articulo);
                Session.Add(Session.SessionID + "articulo", carro);
                Session.Add(Session.SessionID + "Cantidad", carro.ContadorArticulo);
                Session.Add(Session.SessionID + "Total", carro.AcumuladorPrecio);
                Response.Redirect("Carrito.aspx");

            }

        }


       
    }
    }