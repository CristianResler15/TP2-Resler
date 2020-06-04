using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Catalogo_web
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        Articulo Articulo = new Articulo();
        List<Articulo> lista1 = new List<Articulo>();
        bool paso = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            ListaArticulos = negocio.Listar2();
            Carro carrito = new Carro();


            try
            {
                if(Session[Session.SessionID+"Articulo"]!=null)
                {
                    carrito =(Carro) Session[Session.SessionID + "Articulo"];
                }
                LblCantidad.Text = carrito.ContadorArticulo.ToString();
                Session.Add(Session.SessionID + "Cantidad", carrito.ContadorArticulo);
                Session.Add(Session.SessionID + "Total", carrito.AcumuladorPrecio);
                


                string a = (string)Session[Session.SessionID + "Texto"];
                if (!IsPostBack && a=="")
                { //pregunto si es la primera carga de la page
                    repetidor.DataSource = ListaArticulos;
                    repetidor.DataBind();
                    //string a = (string)Session[Session.SessionID + "Texto"];
                }
                else
                {

                    Busqueda(a);

                    //if (paso)
                    //{
                    ListaArticulos = (List<Articulo>)Session[Session.SessionID + "Busqueda"];
                    if (ListaArticulos != null)
                    {
                        repetidor.DataSource = ListaArticulos;
                        repetidor.DataBind();
                      

                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void Busqueda(string txtbusqueda)
        {
            List<Articulo> ListaFiltrada = new List<Articulo>();
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            ListaArticulos = negocio.Listar2();
            if(Session[Session.SessionID +"auxiliar"]!=null)
            {
            paso = (bool)Session[Session.SessionID + "Paso"];
            }
            if (paso)
            {
                string aux = (string)Session[Session.SessionID + "auxiliar"];
                if (aux == txtbusqueda)
                {
                    ListaArticulos = negocio.Listar2();
                    repetidor.DataSource = ListaArticulos;
                    repetidor.DataBind();
                    paso = false;
                    Session.Add(Session.SessionID + "Paso", paso);
                    Session.Add(Session.SessionID + "Texto" , "");                 

                }
                else
                {
                    txtbusqueda = Convert.ToString(Session[Session.SessionID + "Texto"]);
                    ListaFiltrada = ListaArticulos.FindAll(k => k.Categoria.Descripcion.ToLower().Contains(txtbusqueda.ToLower()) || k.Nombre.ToLower().Contains(txtbusqueda.ToLower()) || k.Marca.Descripcion.ToLower().Contains(txtbusqueda.ToLower()));
                    Session.Add(Session.SessionID + "Busqueda", ListaFiltrada);

                    if (Session[Session.SessionID + "Busqueda"] != null)
                    {

                        repetidor.DataSource = ListaFiltrada;
                        repetidor.DataBind();
                    }

                    paso = true;
                    Session.Add(Session.SessionID + "Paso", paso);
                    Session.Add(Session.SessionID + "auxiliar", txtbusqueda);

                }


            }
            else
            {

                txtbusqueda = Convert.ToString(Session[Session.SessionID + "Texto"]);
                ListaFiltrada = ListaArticulos.FindAll(k => k.Categoria.Descripcion.ToLower().Contains(txtbusqueda.ToLower()) || k.Nombre.ToLower().Contains(txtbusqueda.ToLower()));
                Session.Add(Session.SessionID + "Busqueda", ListaFiltrada);

                if (Session[Session.SessionID + "Busqueda"] != null)
                {

                    repetidor.DataSource = ListaFiltrada;
                    repetidor.DataBind();
                }

                paso = true;
                Session.Add(Session.SessionID + "Paso", paso);
                Session.Add(Session.SessionID + "auxiliar", txtbusqueda);

            }

        }

        protected void btnArgumento_Click(object sender, EventArgs e)
        {

            ArtiuloNegocio negocio = new ArtiuloNegocio();
            Carro carro = new Carro();

            try
            {

                ListaArticulos = negocio.Listar2();
                var articuloSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                Articulo = ListaArticulos.Find(J => J.Id == articuloSelec);
                if (Session[Session.SessionID + "articulo"] != null)
                {
                    carro = (Carro)Session[Session.SessionID + "articulo"];
                    
                }
                
                if (!carro.Productos.Exists(A => A.Id == Articulo.Id))
                {
                    carro.Productos.Add(Articulo);
                    carro.AcumuladorPrecio += Articulo.Precio;
                    carro.ContadorArticulo++;
                    Session.Add(Session.SessionID + "articulo", carro);
                    

                }
              
                Response.Redirect("ListarProductos.aspx");
            }
            catch (Exception)
            {


            }

        }

    }
}
