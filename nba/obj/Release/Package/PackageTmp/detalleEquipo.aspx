<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="detalleEquipo.aspx.cs" Inherits="nba.detalleEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-12" ID="txbNombre" runat="server" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" OnServerValidate="cusValNombre_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lbColores" runat="server" Text="Colores"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-12" ID="ddlColores" runat="server">
        <asp:ListItem>Seleccione un color</asp:ListItem>
        <asp:ListItem>amarillo</asp:ListItem>
        <asp:ListItem>negro y rojo</asp:ListItem>
        <asp:ListItem>blanco y azul</asp:ListItem>
        <asp:ListItem>verde</asp:ListItem>
        <asp:ListItem>azul y blanco</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:CustomValidator ID="cusValColores" runat="server" ControlToValidate="ddlColores" Display="Dynamic" OnServerValidate="cusValColores_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lbAnyoFundacion" runat="server" Text="Año de fundación"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-12" ID="ddlAnyoFundacion" runat="server">
        <asp:ListItem>Seleccione un año</asp:ListItem>
        <asp:ListItem>1946</asp:ListItem>
        <asp:ListItem>1974</asp:ListItem>
        <asp:ListItem>1995</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:CustomValidator ID="cusValAnyoFundacion" runat="server" ControlToValidate="ddlAnyoFundacion" Display="Dynamic" OnServerValidate="cusValAnyoFundacion_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/equipos.aspx" Text="Cancelar" />
</asp:Content>
