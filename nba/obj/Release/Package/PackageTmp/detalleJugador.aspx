<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="detalleJugador.aspx.cs" Inherits="nba.detalleJugador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbNombre" runat="server" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="cusValNombre" runat="server" Display="Dynamic" OnServerValidate="cusValNombre_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbAltura" runat="server" Text="Altura"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbAltura" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqAltura" runat="server" Display="Dynamic" ErrorMessage="La altura es requerida" ControlToValidate="txbAltura"></asp:RequiredFieldValidator>
    &nbsp;<asp:RangeValidator ID="ranAltura" runat="server" ControlToValidate="txbAltura" Display="Dynamic" ErrorMessage="La altura debe estar entre 180 cm y 230 cm" MaximumValue="230" MinimumValue="180" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:Label ID="lbPeso" runat="server" Text="Peso"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbPeso" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqPeso" runat="server" Display="Dynamic" ErrorMessage="El peso es requerido" ControlToValidate="txbPeso"></asp:RequiredFieldValidator>
    &nbsp;<asp:RangeValidator ID="ranPeso" runat="server" ControlToValidate="txbPeso" Display="Dynamic" ErrorMessage="El peso debe estar entre 70.0 y 150.0 Kg" MaximumValue="150.0" MinimumValue="70.0" Type="Double"></asp:RangeValidator>
    <br />
    <asp:Label ID="lbDorsal" runat="server" Text="Dorsal"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbDorsal" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqDorsal" runat="server" Display="Dynamic" ErrorMessage="El dorsal es requerido" ControlToValidate="txbDorsal"></asp:RequiredFieldValidator>
    &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txbDorsal" Display="Dynamic" ErrorMessage="El dorsal debe estar entre 0 y 99" MaximumValue="99" MinimumValue="0" Type="Integer"></asp:RangeValidator>
&nbsp;<asp:CustomValidator ID="cusValDorsal" runat="server" ControlToValidate="txbDorsal" Display="Dynamic" OnServerValidate="cusValDorsal_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbEquipo" runat="server" Text="Equipo"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="ddlEquipo" runat="server" AutoPostBack="True">
    </asp:DropDownList>
&nbsp;<asp:CustomValidator ID="cusValEquipo" runat="server" Display="Dynamic" ControlToValidate="ddlEquipo" ErrorMessage="Debe seleccionar un equipo" OnServerValidate="cusValEquipo_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbPosicion" runat="server" Text="Posicion"></asp:Label>
    <br />
    <asp:DropDownList CssClass=" col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="ddlPosicion" runat="server">
    </asp:DropDownList>
&nbsp;<asp:CustomValidator ID="cusValPosicion" runat="server" Display="Dynamic" ControlToValidate="ddlPosicion" ErrorMessage="Debe seleccionar una posición" OnServerValidate="cusValPosicion_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <asp:Button class="bg-dark text-light  col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/jugadores.aspx" Text="Cancelar" />
</asp:Content>
