<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarProductos.aspx.cs" Inherits="Catalogo_web.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista Productos</h1>             
    <asp:Label Text="" ID="LblCantidad"  runat="server"/>
   
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        
          <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("ImagenURL")%>"  class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title text-justify""><%#Eval("Nombre")%></h5>
                        <p class="card-text text-justify""><%#Eval("Descripcion")%></p>
                        <a class="card-text text-justify"><%#Eval("Precio")%></a>
                    </div>
                   <asp:Button CssClass="btn btn-info btn btn-outline-secondary"  ID ="btnArgumento" Text="Agregar al carrito " runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnArgumento_Click"/>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>


</asp:Content>
