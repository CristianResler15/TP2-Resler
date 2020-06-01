<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Catalogo_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



         <style>
            .oculto {
                display: none;
            }
            .Bordes{}

           </style>

        <asp:GridView CssClass="table list-group-item pl-5 pr-5 "  ID="dgvCarrito" runat="server" AutoGenerateColumns="false" Height="259px" Width="473px" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" OnRowCommand="dgvCarrito_RowCommand" >
            <Columns >
                <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger pl-5 pr-5" HeaderText="Opcion" ButtonType="Link" Text="Eliminar" CommandName="Select" />
                <asp:BoundField ControlStyle-CssClass="list-group-item alert-primary  pl-5 pr-5" HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField ControlStyle-CssClass="list-group-item alert-primary  pl-5 pr-5" HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField ControlStyle-CssClass="list-group-item alert-primary  pl-5 pr-5" HeaderText ="Caracteristicas" DataField="Descripcion"/>
                <asp:BoundField ControlStyle-CssClass="list-group-item alert-primary   pl-5 pr-5" HeaderText="Precio" DataField="Precio"/>
                <asp:BoundField ControlStyle-CssClass="list-group-item alert-primary   pl-5 pr-5" HeaderText="Precio" DataField="Precio"/>
            </Columns>
        </asp:GridView>  
      

 
       

</asp:Content>

