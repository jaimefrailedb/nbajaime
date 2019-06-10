<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="nba.usuarios" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbCabecera" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView CssClass="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12" ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="dgv_RowDeleting" OnSelectedIndexChanged="dgv_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Sel" SelectText="►" ShowSelectButton="True" >
            <ControlStyle BackColor="#CCFF33" />
            </asp:CommandField>
            <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" />
            <asp:BoundField DataField="alias" HeaderText="alias" />
            <asp:BoundField DataField="login" HeaderText="login" />
            <asp:BoundField DataField="password" HeaderText="password" />
            <asp:BoundField DataField="movil" HeaderText="movil" />
            <asp:BoundField DataField="mail" HeaderText="mail" />
            <asp:BoundField DataField="acceso" HeaderText="acceso" />
            <asp:BoundField DataField="categoria" HeaderText="categoría" />
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
    <asp:Label ID="lbCategoria" runat="server" Text="Categoría"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="ddlCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnVolver" runat="server" PostBackUrl="~/equipos.aspx" Text="Volver" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAddUsuario" runat="server" OnClick="btnAddUsuario_Click" Text="Añadir usuario" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnExportar" runat="server" PostBackUrl="~/InformeUsuarios.aspx" Text="Exportar" />
    <br />
    <asp:Label ID="lbNoBorrar" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="panelBorrado" runat="server" Visible="False">
        <asp:Label ID="lbBorrado" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button class="bg-dark text-light col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Sí" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button class="bg-dark text-light col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
    </asp:Panel>
</asp:Content>
