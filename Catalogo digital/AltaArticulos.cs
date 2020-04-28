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
    public partial class frmAltaArticulos : Form
    {
        private Articulo articulo = null;
        ArtiuloNegocio Negocio = new ArtiuloNegocio();
        public frmAltaArticulos()
        {
            InitializeComponent();
        }
        public frmAltaArticulos( Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmAltaArticulos_Load(object sender, EventArgs e)
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marca.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoria.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.SelectedIndex = -1;
                cboMarca.SelectedIndex = -1;
                if (articulo != null)
                {
                    txtNombre.Text = articulo.Nombre;
                    txtCodigo.Text = articulo.Codigo;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenURL.Text = articulo.ImagenURL;
                    txtPrecio.Text = Convert.ToString(articulo.Precio);
                    

                    cboMarca.SelectedValue = articulo.Marca.Id;

                    cboCategoria.SelectedValue = articulo.Categoria.Id;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

           
            try
            {
                if (articulo == null)

                    articulo = new Articulo();
                articulo.Codigo = txtCodigo.Text.Trim();
                articulo.Descripcion = txtDescripcion.Text.Trim();
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                articulo.Nombre = txtNombre.Text.Trim();
                articulo.ImagenURL = txtImagenURL.Text.Trim();

                if (articulo.Id != 0)
                {
                    if (MessageBox.Show("¿Finalizar Modificacion?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        Negocio.modificar(articulo);
                    }
                }

                else
                {
                    ValidarDatos();
                    
                }
                
                  

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ValidarDatos()
        {

            bool b = false;



            if (txtNombre.Text.Length == 0 || txtNombre.Text == "¡Ingrese un nombre!")
            {
                txtNombre.Text = "¡Ingrese un nombre!";
                txtNombre.BackColor = Color.IndianRed;

                b = true;
            }


            if (txtDescripcion.Text.Length == 0 || txtDescripcion.Text == "¡Ingrese una descripcion!")
            {
                txtDescripcion.Text = "¡Ingrese una descripcion!";
                txtDescripcion.BackColor = Color.IndianRed;
                b = true;
            }


            if (txtCodigo.Text.Length == 0 || txtCodigo.Text == "¡Ingrese un codigo!")
            {
                txtCodigo.Text = "¡Ingrese un codigo!";
                txtCodigo.BackColor = Color.IndianRed;
                b = true;
            }

            if (cboCategoria.Text.Length == 0 || cboCategoria.Text == "¡Seleccione una categoria!")
            {
                cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cboCategoria.Text = "¡Seleccione una categoria!";

                cboCategoria.BackColor = Color.IndianRed;
                cboCategoria.ForeColor = Color.WhiteSmoke;
                b = true;
            }

            if (cboMarca.Text.Length == 0 || cboMarca.Text == "¡Seleccione una marca!")
            {
                cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cboMarca.Text = "¡Seleccione una marca!";
                cboMarca.BackColor = Color.IndianRed;
                cboMarca.ForeColor = Color.WhiteSmoke;
                b = true;
            }

            if (b == false)
            {
                if (MessageBox.Show("¿Finalizar agregar?", "Alta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Negocio.Agregar(articulo);
                    MessageBox.Show("Se ha cargado con exito");
                    Dispose();

                }
            }



        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.White;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.White;
        }

        private void cboMarca_DropDown(object sender, EventArgs e)
        {
            cboMarca.ForeColor = Color.Black;
            cboMarca.Text = "";
        }

        private void cboMarca_DropDownClosed(object sender, EventArgs e)
        {
            cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           
        }

        private void cboCategoria_DropDownClosed(object sender, EventArgs e)
        {
            cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void cboCategoria_DropDown(object sender, EventArgs e)
        {

            cboCategoria.ForeColor = Color.Black;
            cboCategoria.Text = "";
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.White;
        }
    }
}
