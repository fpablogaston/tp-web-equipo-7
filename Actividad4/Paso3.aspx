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
        <asp:TextBox ID="textDni" cssClass="form-control" runat="server" OnTextChanged="textDni_TextChanged" AutoPostBack="true"></asp:TextBox>
         <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredDni" runat="server" ErrorMessage="Por favor ingrese DNI" ForeColor="Red" ControlToValidate="textDni"></asp:RequiredFieldValidator>
        <%--<asp:RegularExpressionValidator ID="RegularExDni" runat="server" ErrorMessage="Solo se aceptan numeros" ControlToValidate="textDni" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>--%>
        <asp:RegularExpressionValidator ID="RegexDni" runat="server" ControlToValidate="textDni" CssClass="text-danger small mt-1 d-block" ErrorMessage="El DNI es inválido" ValidationExpression="^\d{7,8}$" ForeColor="Red"> </asp:RegularExpressionValidator>
    </div>

    <div class="row">
    <div class="col-md-3">
        <label  class="form-label">Nombre</label>
        <asp:TextBox type="text" ID="textName" cssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredNombre" runat="server" ErrorMessage="Por favor ingrese un Nombre" ForeColor="Red" ControlToValidate="textName" ></asp:RequiredFieldValidator>
    </div>

    <div class="col-3">
        <label class="form-label">Apellido</label>
        <asp:TextBox type="text" ID="TextApellido" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredApellido" runat="server" ErrorMessage="Por favor ingrese su Apellido" ForeColor="Red" ControlToValidate="TextApellido"></asp:RequiredFieldValidator>
    </div>
    </div>

    <div class="col-6">
        <label class="form-label">Email</label>
        <asp:TextBox ID="TextEmail" type="text" class="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredEmail" runat="server" ErrorMessage="Por favor ingrese un email" ForeColor="Red" ControlToValidate="TextEmail"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegexEmail" runat="server" ControlToValidate="TextEmail" ErrorMessage="Ingrese un correo electrónico válido" CssClass="text-danger small mt-1 d-block" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" OnTextChanged="TextEmail_TextChanged"> </asp:RegularExpressionValidator>
    </div>

<div class="row">
    <div class="col-md-2">
        <label class="form-label">Direccion</label>
        <asp:TextBox ID="TextDireccion" class="form-control" type="text" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredDireccion" runat="server" ErrorMessage="Por favor ingrese Direccion" ForeColor="Red" ControlToValidate="TextDireccion"></asp:RequiredFieldValidator>
    </div>

    <div class="col-md-2">
        <label class="form-label">Ciudad</label>
        <asp:TextBox ID="TextCiudad" class="form-control" type="text" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredCiudad" runat="server" ErrorMessage="Por favor ingrese una Ciudad" ForeColor="Red" ControlToValidate="TextCiudad"></asp:RequiredFieldValidator>
    </div>
    
    <div class="col-md-2">
        <label class="form-label">CP</label>
        <asp:TextBox ID="TextCP" type="number" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="ParticiparGroup" ID="RequiredCP" runat="server" ErrorMessage="Por favor ingresar CP" ForeColor="Red" ControlToValidate="TextCP"></asp:RequiredFieldValidator>
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
        <asp:Button ValidationGroup="ParticiparGroup" type="submit" ID="btnParticipar" CssClass="btn btn-primary" OnClick="btnParticipar_Click" runat="server" Text="Participar!" />
    </div>
</asp:Content>
