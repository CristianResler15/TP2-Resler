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
    public partial class formulario : Form
    {

        private List<Articulo>Lista;
        public formulario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ArtiuloNegocio negocio = new Negocio.ArtiuloNegocio();
            dgvArticulo.DataSource = negocio.Listar2();
        }

        private void formulario_Load(object sender, EventArgs e)
        {

            CargarDatos();

        }
        private void CargarDatos()
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            try
            {
                Lista=negocio.Listar2();
                dgvArticulo.DataSource = Lista;
                dgvArticulo.Columns[0].Visible = false;
                dgvArticulo.Columns[1].Visible = false;
                dgvArticulo.Columns[5].Visible = false;
                dgvArticulo.Columns[6].Visible = false;
                dgvArticulo.Columns[0].Visible = false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        private void dgvArticulo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Articulo articulos;
                articulos = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                try
                {
                    pbImagen.Load(articulos.ImagenURL);
                    
                }
                catch (Exception)
                {

                    pbImagen.Load("http://www.canaleducativo2.icrt.cu/img/default.png"); 

                }  
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaArticulos Alta = new frmAltaArticulos();
            Alta.ShowDialog();
            CargarDatos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            Articulo modificar;
            formulario a = new formulario();
            modificar = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmAltaArticulos frmModificar = new frmAltaArticulos(modificar);
            frmModificar.Text = "Modificar";
            

            frmModificar.ShowDialog();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArtiuloNegocio negocio = new ArtiuloNegocio();
            try
            {
                int id = ((Articulo)dgvArticulo.CurrentRow.DataBoundItem).Id;
                if (MessageBox.Show("¿Esta seguro que quiere eliminar articulo?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    negocio.eliminar(id);
                    CargarDatos();

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

     

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
                
            try
            {
                if (txtBusqueda.Text == "")
                {
                    dgvArticulo.DataSource = Lista;
                 
                }
                else
                {
                    var ListaFiltrada = Lista.FindAll(k => k.Categoria.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())|| k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower())|| k.Marca.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()));
                    dgvArticulo.DataSource = ListaFiltrada;

                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void bnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo Detalles;
                Detalles = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                frmDetalles frmDetalles = new frmDetalles(Detalles);
                frmDetalles.ShowDialog();
                CargarDatos();
            }
            
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

       
    }
}
