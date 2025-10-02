<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Actividad4._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label fw-bold">Ingresa el codigo de tu voucher!</label>
                <asp:TextBox ID="TextCodigo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button Text="Siguiente" CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" type="submit"   runat="server"  />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
