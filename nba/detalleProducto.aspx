<%@  Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="nba.detalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbNombre" runat="server" MaxLength="20"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" OnServerValidate="cusValNombre_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbDescripcion" runat="server" Text="Descripción"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbDescripcion" runat="server" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqDescripcion" runat="server" ControlToValidate="txbDescripcion" Display="Dynamic" ErrorMessage="La descripción es requerida"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValDescripcion" runat="server" ControlToValidate="txbDescripcion" Display="Dynamic" OnServerValidate="cusValDescripcion_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbCantidad" runat="server" Text="Cantidad"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbCantidad" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqCantidad" runat="server" ControlToValidate="txbCantidad" Display="Dynamic" ErrorMessage="La cantidad es requerida"></asp:RequiredFieldValidator>
&nbsp;<asp:RangeValidator ID="ranCantidad" runat="server" ControlToValidate="txbCantidad" Display="Dynamic" ErrorMessage="La cantidad debe estar entre 1 y 100" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:Label ID="lbPrecio" runat="server" Text="Precio"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbPrecio" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqPrecio" runat="server" ControlToValidate="txbPrecio" Display="Dynamic" ErrorMessage="El precio es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:RangeValidator ID="ranPrecio" runat="server" ControlToValidate="txbPrecio" Display="Dynamic" ErrorMessage="El precio debe estar entre 1.0 y 100.0 €" MaximumValue="100.0" MinimumValue="1.0" Type="Double"></asp:RangeValidator>
    <br />
    <asp:Label ID="lbEquipos" runat="server" Text="Equipo"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="ddlEquipos" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <asp:CustomValidator ID="cusValddl" runat="server" ControlToValidate="ddlEquipos" Display="Dynamic" ErrorMessage="Debe seleccionar un equipo" OnServerValidate="cusValddl_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button class="bg-dark text-light  col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light  col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/productos.aspx" Text="Cancelar" />
</asp:Content>
