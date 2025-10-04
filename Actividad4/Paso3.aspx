<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paso3.aspx.cs" Inherits="Actividad4.Paso3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
             <div class="bg-dark text-white p-2 mb-3">
                <h1 class="m-0">Paso 3</h1>
             </div>

    <h2>Ingresá tus datos</h2>

    <div class="col-md-2">
        <label type="number" class="form-label">DNI</label>
        <asp:TextBox ID="textDni" cssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="btnDni" cssClass="btn btn-primary" OnClick="btnDni_Click" runat="server" Text="Chequear DNI" />
    </div>

    <div class="row">
    <div class="col-md-3">
        <label  class="form-label">Nombre</label>
        <asp:TextBox type="text" ID="textName" cssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="col-3">
        <label class="form-label">Apellido</label>
        <asp:TextBox type="text" ID="TextApellido" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    </div>

    <div class="col-6">
        <label class="form-label">Email</label>
        <asp:TextBox ID="TextEmail" type="text" class="form-control" runat="server"></asp:TextBox>
    </div>

<div class="row">
    <div class="col-md-2">
        <label class="form-label">Direccion</label>
        <asp:TextBox ID="TextDireccion" class="form-control" type="text" runat="server"></asp:TextBox>
    </div>

    <div class="col-md-2">
        <label class="form-label">Ciudad</label>
        <asp:TextBox ID="TextCiudad" class="form-control" type="text" runat="server"></asp:TextBox>
    </div>
    
    <div class="col-md-2">
        <label class="form-label">CP</label>
        <asp:TextBox ID="TextCP" type="number" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
</div>

    <div class="col-12">
        <div class="form-check">
            <input class="form-check-input" type="checkbox" id="gridCheck">
            <label class="form-check-label" for="gridCheck">
                Acepto los terminos y condiciones
            </label>
        </div>
    </div>

    <div class="col-12">
        <asp:Button type="submit" ID="btnParticipar" CssClass="btn btn-primary" OnClick="btnParticipar_Click" runat="server" Text="Participar!" />
    </div>
</asp:Content>
