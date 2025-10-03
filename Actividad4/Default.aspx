<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Actividad4._default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<h1> BIENVENIDO </h1> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label ID="lblEjemplo" class="form-label fw-bold">Ingresa el código de tu voucher!</label>
                <asp:TextBox ID="TextCodigo" CssClass="form-control placeholder-gray" runat="server" Text="XXXXXX" OnFocus="vaciar(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe introducir un código" ControlToValidate="TextCodigo" runat="server" />
                <asp:Panel ID="pnlResultado" runat="server" CssClass="alert alert-success alert-dismissible fade show mt-2" Visible="false"></asp:Panel>
            </div>
            <asp:Button Text="Canjear" CssClass="estilos.css btn-primary" ID="btnCanjear" OnClick="btnCanjear_Click" type="submit"   runat="server"  />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
