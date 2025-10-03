<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paso2.aspx.cs" Inherits="Actividad4.Paso2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Paso 2</h1>
    <p>Seleccioná tu premio.</p>

    <div class="container mt-4">
  <div class="row row-cols-1 row-cols-md-3 g-4">
    <% foreach (dominio.Articulo articulo in ListaArticulos) { %>
      <div class="col">
        <div class="card h-100 shadow-sm">
          
          <div id="carousel_<%: articulo.IdArticulo %>" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
              <% for (int i = 0; i < articulo.Imagenes.Count; i++) { %>
                <div class="carousel-item <%: (i == 0 ? "active" : "") %>">
                  <img src="<%: articulo.Imagenes[i] %>" class="card-img-fixed" alt="img">
                </div>
              <% } %>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carousel_<%: articulo.IdArticulo %>" data-bs-slide="prev">
              <span class="carousel-control-prev-icon"></span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carousel_<%: articulo.IdArticulo %>" data-bs-slide="next">
              <span class="carousel-control-next-icon"></span>
            </button>
          </div>

          
          <div class="card-body text-center">
            <h5 class="card-title"><%: articulo.Nombre %></h5>
            <p class="card-text"><%: articulo.Descripcion %></p>
            <p class="fw-bold">$<%: articulo.Precio.ToString("0.00") %></p>
            <a href="#Paso3.aspx" class="estilos.css btn btn-danger">Reclamar</a>
          </div>
        </div>
      </div>
    <% } %>
  </div>
</div>
</asp:Content>