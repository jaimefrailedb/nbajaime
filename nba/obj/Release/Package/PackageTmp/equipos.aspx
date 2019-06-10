<%@  Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="equipos.aspx.cs" Inherits="nba.equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label CssClass="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6" ID="lbColores" runat="server" Text="Color(es)"></asp:Label>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label CssClass="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6" ID="lbAnyoFundacion" runat="server" Text="Año de fundación"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-4" ID="ddlColores" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColores_SelectedIndexChanged">
        <asp:ListItem>Seleccione un color</asp:ListItem>
        <asp:ListItem>amarillo</asp:ListItem>
        <asp:ListItem>negro y rojo</asp:ListItem>
        <asp:ListItem>blanco y azul</asp:ListItem>
        <asp:ListItem>verde</asp:ListItem>
        <asp:ListItem>azul y blanco</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-4 col-4" ID="ddlAnyoFundacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnyoFundacion_SelectedIndexChanged">
        <asp:ListItem>Seleccione un año</asp:ListItem>
        <asp:ListItem>1946</asp:ListItem>
        <asp:ListItem>1974</asp:ListItem>
        <asp:ListItem>1995</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbResultados" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView CssClass="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12" ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="dgv_RowDeleting" OnSelectedIndexChanged="dgv_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Sel" SelectText="►" ShowSelectButton="True" >
            <ControlStyle BackColor="#CCFF33" ForeColor="Black" Font-Bold="True" />
            </asp:CommandField>
            <asp:BoundField DataField="idEquipo" HeaderText="idEquipo" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" />
            <asp:BoundField DataField="colores" HeaderText="colores" />
            <asp:BoundField DataField="anyoFundacion" HeaderText="Año de fundación" />
            <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True" >
            <ControlStyle BackColor="Red" ForeColor="White" Font-Bold="True" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <br />
    <br />
    <asp:Panel ID="panelBotones" runat="server">
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnGestionUsuarios" runat="server" Text="Gestión Usuarios" PostBackUrl="~/usuarios.aspx" />
        
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAddEquip" runat="server" Text="Añadir equipo" OnClick="btnAddEquip_Click" />
        
        <asp:Button class="bg-dark text-light col-xl-1 col-lg-1 col-md-1 col-sm-1 col-12" ID="btnVolver" runat="server" PostBackUrl="~/Default.aspx" Text="Volver" OnClick="btnVolver_Click" />
        
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnJugadores" runat="server" Text="Jugadores" PostBackUrl="~/jugadores.aspx" />
        
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnProductos" runat="server" PostBackUrl="~/productos.aspx" Text="Productos" />
        
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnExportar" runat="server" Text="Exportar" PostBackUrl="~/informeEquipos.aspx" />
        <br />
        <asp:Label ID="lbNoBorrado" runat="server"></asp:Label>
        <asp:Panel ID="panelBorrado" runat="server" Visible="False">
            <asp:Label ID="lbBorrar" runat="server"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Sí" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
