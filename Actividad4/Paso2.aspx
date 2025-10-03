<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paso2.aspx.cs" Inherits="Actividad4.Paso2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-dark text-white p-2 mb-3">
       <h1 class="m-0">Paso 2</h1>
    </div>
    <p>Seleccioná tu premio.</p>

    <div class="container mt-4">
  <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="rptArticulos_ItemCommand">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100 shadow-sm">
                    <div id="carousel_<%# Eval("IdArticulo") %>" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                <ItemTemplate>
                                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                        <img src='<%# Container.DataItem %>' class="card-img-fixed" alt="img" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel_<%# Eval("IdArticulo") %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel_<%# Eval("IdArticulo") %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </button>
                    </div>

                    <div class="card-body text-center">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <p class="fw-bold">$<%# Eval("Precio", "{0:0.00}") %></p>
                        <asp:Button 
                            ID="btnReclamar" 
                            runat="server" 
                            CssClass="btn btn-danger" 
                            Text="Reclamar" 
                            CommandName="Reclamar"
                            CommandArgument='<%# Eval("IdArticulo") %>' 
                            /> 
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

</asp:Content>