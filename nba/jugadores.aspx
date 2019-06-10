<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="jugadores.aspx.cs" Inherits="nba.jugadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbCabecera" runat="server"></asp:Label>
    <br />
    <br />
    
        <asp:GridView class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12" ID="dgv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="dgv_RowDeleting" OnSelectedIndexChanged="dgv_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="dgv_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" EditText="►" HeaderText="Edit" SelectText="►" ShowSelectButton="True" >
                <ControlStyle BackColor="#CCFF33" />
                </asp:CommandField>
                <asp:BoundField DataField="idJugador" HeaderText="idJugador" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" />
                <asp:BoundField DataField="altura" HeaderText="altura" />
                <asp:BoundField DataField="peso" HeaderText="peso" />
                <asp:BoundField DataField="Equipo" HeaderText="equipo" />
                <asp:BoundField DataField="dorsal" HeaderText="dorsal" />
                <asp:BoundField DataField="equipo_id" HeaderText="equipo_id" />
                <asp:BoundField DataField="Posicion" HeaderText="posicion" />
                <asp:BoundField DataField="posicion_id" HeaderText="posicion_id" />
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True" >
                <ControlStyle BackColor="Red" ForeColor="White" />
                </asp:CommandField>
            </Columns>
            <EmptyDataTemplate>
                Edit
            </EmptyDataTemplate>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbEquipos" runat="server" Text="Equipos"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbPosicion" runat="server" Text="Posición"></asp:Label>
    <br />
    <asp:DropDownList CssClass=" col-xl-3 col-lg-3 col-md-3 col-sm-3 col-3" ID="ddlEquipos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEquipos_SelectedIndexChanged">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList CssClass=" col-xl-3 col-lg-3 col-md-3 col-sm-3 col-3" ID="ddlPosiciones" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPosiciones_SelectedIndexChanged">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAddJugador" runat="server" OnClick="btnAddJugador_Click" Text="Añadir Jugador" />
&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-1 col-lg-1 col-md-1 col-sm-1 col-12" ID="btnVolver" runat="server" PostBackUrl="~/equipos.aspx" Text="Volver" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnExportar" runat="server" PostBackUrl="~/informeJugadores.aspx" Text="Exportar" />
    <br />
    <asp:Panel ID="panelBorrado" runat="server" Visible="False">
        <asp:Label ID="lbBorrar" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Sí" />
        &nbsp;
        <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
    </asp:Panel>
</asp:Content>
