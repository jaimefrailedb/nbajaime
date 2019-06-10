<%@ Page  Theme="general" Title="" Language="C#"  AutoEventWireup="true" CodeBehind="recordarPass.aspx.cs" Inherits="nba.recordarPass" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baloncesto</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="css/estilos.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">

    <asp:Label ID="lbMail" runat="server" Text="Mail"></asp:Label>
    <br />
    <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbMail" runat="server" MaxLength="100" ToolTip="Utilice un mail existente, para en caso de olvido poder recuperar su contraseña"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reqMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="El mail es requerido"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="regMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="El mail no es válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
&nbsp;<asp:CustomValidator ID="cusValMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" OnServerValidate="cusValMail_ServerValidate"></asp:CustomValidator>
    <br />
    <br />
    <br />
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnVolver" runat="server" CausesValidation="False" PostBackUrl="~/Default.aspx" Text="Volver" />
        <br />
        <br />
        <asp:Label ID="lbAviso" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="panelCambiaPass" runat="server" Visible="False">
            <asp:Label ID="lbPassActual" runat="server" Text="Contraseña Actual"></asp:Label>
            <br />
            <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbPassActual" runat="server" MaxLength="10"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="reqPassActual" runat="server" ControlToValidate="txbPassActual" Display="Dynamic" ErrorMessage="La contraseña actual es requerida"></asp:RequiredFieldValidator>
            &nbsp;<asp:CustomValidator ID="cusValPassActual" runat="server" ControlToValidate="txbPassActual" Display="Dynamic" OnServerValidate="cusValPassActual_ServerValidate" ValidationGroup="pass"></asp:CustomValidator>
            <br />
            <asp:Label ID="lbNuevaPass" runat="server" Text="Nueva Contraseña"></asp:Label>
            <br />
            <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbNuevaPass" runat="server" MaxLength="100"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="reqNuevaPass" runat="server" ControlToValidate="txbNuevaPass" Display="Dynamic" ErrorMessage="Debe introducir la nueva contraseña" ValidationGroup="pass"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbRepPass" runat="server" Text="Repite Contraseña"></asp:Label>
            <br />
            <asp:TextBox class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbRepPass" runat="server" MaxLength="10"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="reqRepPass" runat="server" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="Debe repetir la contraseña" ValidationGroup="pass"></asp:RequiredFieldValidator>
            &nbsp;<asp:CompareValidator ID="compPass" runat="server" ControlToCompare="txbNuevaPass" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="La nueva contraseña no coincide" ValidationGroup="pass"></asp:CompareValidator>
        </asp:Panel>
        <br />
        <asp:Button ID="btnCambiaPass" CssClass="bg-dark text-light col-xl-4 col-lg-4 col-md-4 col-sm-4 col-12" runat="server" Text="Cambiar Contraseña" ValidationGroup="pass" Enabled="False" OnClick="btnCambiaPass_Click" />
        <br />
        <br />
        <asp:Label ID="lbExito" runat="server"></asp:Label>
</div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        
</form>
    </body>
</html>

