using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Catalogo_digital
{
    public partial class frmDetalles : Form
    {
        private Articulo articulo = null;
        public frmDetalles()
        {
            InitializeComponent();
        }
        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        

        private void frmDetalles_Load(object sender, EventArgs e)
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            try
            {
                txtCategoriaDetalles.Text = articulo.Categoria.Descripcion;
                txtMarcaDetalles.Text = articulo.Marca.Descripcion;
                
                
                if (articulo != null)
                {
                    txtNombreDetalles.Text = articulo.Nombre;
                    txtCodigoDetalles.Text = articulo.Codigo;
                    txtDescripcionDetalles.Text = articulo.Descripcion;
                    lbRuta.Text = articulo.ImagenURL;
                    txtPrecioDetalles.Text = Convert.ToString(articulo.Precio);

                    try
                    {
                        try
                        {
                            pbImagenDetalles.Load(articulo.ImagenURL);
                        }
                        catch (Exception)
                        {

                            pbImagenDetalles.Load("http://www.canaleducativo2.icrt.cu/img/default.png");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
