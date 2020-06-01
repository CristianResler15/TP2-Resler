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
    public partial class SiteMaster : MasterPage
    {
        String a;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack && Session[Session.SessionID +"Texto"]==null)
            //{
            //    a = "";
            //}
            //else
            //{
            //    txtBusqueda.Text =(string)Session[Session.SessionID+"Texto"];
            //}
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

             a = txtBusqueda.Text;
            Session.Add(Session.SessionID + "Texto",a);
            Response.Redirect("ListarProductos.aspx");
           
        }
    }

}