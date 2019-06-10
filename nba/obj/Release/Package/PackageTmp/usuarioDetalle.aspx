<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="usuarioDetalle.aspx.cs" Inherits="nba.usuarioDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbNombre" runat="server" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" OnServerValidate="cusValNombre_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbAlias" runat="server" Text="Alias"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbAlias" runat="server" MaxLength="4"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqAlias" runat="server" ControlToValidate="txbAlias" Display="Dynamic" ErrorMessage="El alias es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValAlias" runat="server" ControlToValidate="txbAlias" Display="Dynamic" OnServerValidate="cusValAlias_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbLogin" runat="server" Text="Login"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbLogin" runat="server" MaxLength="10"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqLogin" runat="server" ControlToValidate="txbLogin" Display="Dynamic" ErrorMessage="El login es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:CustomValidator ID="cusValLogin" runat="server" ControlToValidate="txbLogin" Display="Dynamic" OnServerValidate="cusValLogin_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbPass" runat="server" Text="Contraseña"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbPass" runat="server" MaxLength="10"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqPass" runat="server" ControlToValidate="txbPass" Display="Dynamic" ErrorMessage="La contraseña es requerida"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbRepitePass" runat="server" Text="Repite contraseña"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbRepPass" runat="server" MaxLength="10"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqRepPass" runat="server" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="Debe repetir la contraseña"></asp:RequiredFieldValidator>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbPass" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
    <br />
    <asp:Label ID="lbMovil" runat="server" Text="Móvil"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbMovil" runat="server" MaxLength="9"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" ErrorMessage="El móvil es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:RangeValidator ID="ranMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" ErrorMessage="El móvil debe empezar por 6 o 7" MaximumValue="799999999" MinimumValue="600000000" Type="Integer"></asp:RangeValidator>
&nbsp;<asp:CustomValidator ID="cusValMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" OnServerValidate="cusValMovil_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbMail" runat="server" Text="Mail"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbMail" runat="server" MaxLength="100" ToolTip="Utilice un mail existente, para en caso de olvido poder recuperar su contraseña"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="El mail es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="regMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="El mail no es correcto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;<asp:CustomValidator ID="cusValMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" OnServerValidate="cusValMail_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbCategoria" runat="server" Text="Categoría"></asp:Label>
    <br />
    <asp:DropDownList CssClass=" col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="ddlCategoria" runat="server">
    </asp:DropDownList>
&nbsp;<br />
    <br />
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/usuarios.aspx" Text="Cancelar" />
</asp:Content>
