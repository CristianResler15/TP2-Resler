<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarProductos.aspx.cs" Inherits="Catalogo_web.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista Productos</h1>  
    <div>   
     <%--<asp:img src="~/Image/Carrito.jpg" alt="Carrito"/>--%>
        <asp:Image ImageUrl="~/Image/Carrito.svg" CssClass="float-right" Width=30px Height=30px runat="server" />
        <asp:Label CssClass="float-right"  Text="" ID="LblCantidad"  runat="server"/>
    </div>
   
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        
          <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card">
                   <div class="card-header">
                      <h3 class="card-title text-center ""><%#Eval("Nombre")%></h3>
                   </div>
                    <img src="<%#Eval("ImagenURL")%>" Style= "max-width=200px;"  class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text text-center "><%#Eval("Descripcion")%></p>
                        <p class="card-text text-center "><%#Eval("marca")%></p>
                        <p class="card-text text-center "><%#Eval("Precio")%></p>
                    </div>
                   <asp:Button CssClass="btn btn-info btn btn-outline-secondary align-items-md-center"  ID ="btnArgumento" Text="Agregar al carrito " runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnArgumento_Click"/>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>


</asp:Content>
