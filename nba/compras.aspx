<%@ Page Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="nba.compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbCabecera" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbProducto" runat="server" Text="Producto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Label ID="lbUsuario" runat="server" Text="Usuario"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-3" ID="ddlProductos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-3" ID="ddlUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:GridView CssClass="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12" ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="dgv_RowDeleting" OnSelectedIndexChanged="dgv_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="dgv_PageIndexChanging" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="Sel" SelectText="►" ShowSelectButton="True" />
            <asp:BoundField DataField="idCompra" HeaderText="idCompra" />
            <asp:BoundField DataField="producto" HeaderText="producto" />
            <asp:BoundField DataField="producto_id" HeaderText="producto_id" />
            <asp:BoundField DataField="usuario" HeaderText="usuario" />
            <asp:BoundField DataField="usuario_id" HeaderText="usuario_id" />
            <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
            <asp:BoundField DataField="fecha" HeaderText="fecha" />
            <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True" >
            <ControlStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
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
    &nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnComprar" runat="server" OnClick="btnComprar_Click" Text="Comprar" />
&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnVolver" runat="server" PostBackUrl="~/productos.aspx" Text="Volver" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnExportar" runat="server" Text="Exportar" PostBackUrl="~/informeCompras.aspx" />
    <br />
    <asp:Panel ID="panelBorrado" runat="server" Visible="False">
        <asp:Label ID="lbBorrado" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Sí" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
    </asp:Panel>
</asp:Content>
