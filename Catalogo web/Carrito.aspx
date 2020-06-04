<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Catalogo_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



         <style>
            .oculto {
                display: none;
            }
            .bolsita
            {
                background-image:url('../Image/Carro.png');
                background-size:cover;
                width:50px;
                height:50px;

            }
          

           </style>
    <div class="bolsita float-right mt-5"  >   
         <br />
         <asp:Label Text="" ID="LblCarrito" Style="font-size:20px;" CssClass=" ml-4 mt-2 font-weight-light"  runat="server" />
    </div> 
    <div class=" float-right mt-5" >   
         <br />

        <asp:Label Text="TOTAL:" ID="LblTotal" CssClass=" float-md-left mt-5 ml-5 badge bg-success "  Style=font-size:25px;  runat="server" />
    </div>
        <asp:GridView CssClass=" table  table-success table-hover "  ID="dgvCarrito" runat="server" AutoGenerateColumns="false"  OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" OnRowCommand="dgvCarrito_RowCommand"  >      
           <Columns  >
                
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder bg-primary" ButtonType="Link" Text="Eliminar" CommandName="Select" />
                <asp:BoundField  HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField ItemStyle-CssClass=" align-items-xl-center " HeaderStyle-CssClass="bg-primary" HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center " HeaderStyle-CssClass=" bg-primary" HeaderText ="Caracteristicas" DataField="Descripcion"/>
                <asp:BoundField ItemStyle-CssClass="align-items-xl-center " HeaderStyle-CssClass=" bg-primary " HeaderText="Precio" DataField="Precio"/>
            </Columns>
        </asp:GridView> 
        
   
      

 
       

</asp:Content>

