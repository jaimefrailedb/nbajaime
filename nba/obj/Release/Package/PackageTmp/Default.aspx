<%@ Page Theme="general" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nba.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baloncesto</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="css/estilos.css" type="text/css" />
</head>
<body class="container">
    <form id="form1" runat="server">
    <div style="float:left">
    
        <asp:Panel ID="Panel1" runat="server" Height="479px" Width="454px">
            <asp:Label ID="lbUsuario" runat="server" Text="Usuario"></asp:Label>
            <br />
            <asp:TextBox ID="txbUsuario" runat="server" MaxLength="10"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="reqUsuario" runat="server" ControlToValidate="txbUsuario" Display="Dynamic" ErrorMessage="El usuario es requerido" ValidationGroup="log"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lbPass" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="txbPass" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="reqPass" runat="server" ControlToValidate="txbPass" Display="Dynamic" ErrorMessage="La contraseña es requerida" ValidationGroup="log"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button class="bg-dark text-light" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="log" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button class="bg-dark text-light" ID="btnRecPass" runat="server" CausesValidation="False"  PostBackUrl="~/recordarPass.aspx" Text="Recordar contraseña" />
            <br />
            <br />
            <asp:Label ID="lbError" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
        </asp:Panel>
        
    
    </div>

        <div style="float:right;margin-top:0; height: 480px; margin-left: 104px; top: -259px; left: 449px;">
            <asp:Panel ID="PanelReg" runat="server" Height="545px" Width="520px" Visible="False">
                <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <asp:TextBox ID="txbNombre" runat="server" MaxLength="50"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="ReqNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
                &nbsp;<asp:CustomValidator ID="cusValNombre" runat="server" ControlToValidate="txbNombre" Display="Dynamic" OnServerValidate="cusValNombre_ServerValidate"></asp:CustomValidator>
                <br />
                <br />
                <asp:Label ID="lbAlias" runat="server" Text="Alias"></asp:Label>
                <br />
                <asp:TextBox ID="txbAlias" runat="server" MaxLength="4"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqAlias" runat="server" ControlToValidate="txbAlias" Display="Dynamic" ErrorMessage="El alias es requerido"></asp:RequiredFieldValidator>
                &nbsp;<asp:CustomValidator ID="cusValAlias" runat="server" ControlToValidate="txbAlias" Display="Dynamic" OnServerValidate="cusValAlias_ServerValidate"></asp:CustomValidator>
                <br />
                <br />
                <asp:Label ID="lbLogin" runat="server" Text="Login"></asp:Label>
                <br />
                <asp:TextBox ID="txbLogin" runat="server" MaxLength="10"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqLogin" runat="server" ControlToValidate="txbLogin" Display="Dynamic" ErrorMessage="El login es requerido"></asp:RequiredFieldValidator>
                &nbsp;<asp:CustomValidator ID="cusValLogin" runat="server" Display="Dynamic" OnServerValidate="cusValLogin_ServerValidate"></asp:CustomValidator>
                <br />
                <br />
                <asp:Label ID="lbPassReg" runat="server" Text="Contraseña"></asp:Label>
                <br />
                <asp:TextBox ID="txbPassReg" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqPassReg" runat="server" ControlToValidate="txbPassReg" Display="Dynamic" ErrorMessage="La contraseña es requerida"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lbRepPass" runat="server" Text="Repite contraseña"></asp:Label>
                <br />
                <asp:TextBox ID="txbRepPass" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqRepPass" runat="server" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="Debe repetir la contraseña"></asp:RequiredFieldValidator>
                &nbsp;<asp:CompareValidator ID="compPass" runat="server" ControlToCompare="txbPassReg" ControlToValidate="txbRepPass" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                <br />
                <br />
                <asp:Label ID="lbMovil" runat="server" Text="Móvil"></asp:Label>
                <br />
                <asp:TextBox ID="txbMovil" runat="server" MaxLength="9"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" ErrorMessage="El móvil es requerido"></asp:RequiredFieldValidator>
                &nbsp;<asp:RangeValidator ID="ranMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" ErrorMessage="El móvil debe ser de 9 cifras y empezar por 6 o 7" MaximumValue="799999999" MinimumValue="600000000" Type="Integer"></asp:RangeValidator>
                &nbsp;<asp:CustomValidator ID="cusValMovil" runat="server" ControlToValidate="txbMovil" Display="Dynamic" OnServerValidate="cusValMovil_ServerValidate"></asp:CustomValidator>
                <br />
                <br />
                <asp:Label ID="lbMail" runat="server" Text="Mail"></asp:Label>
                <br />
                <asp:TextBox ID="txbMail" runat="server" MaxLength="100" ToolTip="Utilice un mail existente, para en caso de olvido poder recuperar su contraseña"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="reqMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="El mail es requerido"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbMail" Display="Dynamic" ErrorMessage="Mail no válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                &nbsp;<asp:CustomValidator ID="cusValMail" runat="server" ControlToValidate="txbMail" Display="Dynamic" OnServerValidate="cusValMail_ServerValidate"></asp:CustomValidator>
                
            </asp:Panel>
            <br /><br /><br />
            <asp:Button class="bg-dark text-light" ID="btnRegistro" runat="server" Text="Regístrate" OnClick="btnRegistro_Click" />
            <br /><br /><br />
            <asp:Label ID="lbExito" runat="server"></asp:Label>
        </p>
        </div>
        
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
