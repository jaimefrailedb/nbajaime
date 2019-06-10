<%@ Page  Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="detalleCompra.aspx.cs" Inherits="nba.detalleCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbProducto" runat="server" Text="Producto"></asp:Label>
    <br />
    <asp:DropDownList CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12" ID="ddlProducto" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    &nbsp;<asp:CustomValidator ID="cusValProducto" runat="server" ControlToValidate="ddlProducto" Display="Dynamic"></asp:CustomValidator>
    <br />
    <asp:Label ID="lbMensaje" runat="server" Text="No puede realizar la compra porque no hay existencias suficientes" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lbUsuario" runat="server" Text="Usuario" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="txbUsuario" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
    &nbsp;<br />
    <asp:Label ID="lbCantidad" runat="server" Text="Cantidad"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbCantidad" runat="server"></asp:TextBox>
    &nbsp;<asp:CustomValidator ID="cusValCantidad" runat="server" ControlToValidate="txbCantidad" Display="Dynamic" OnServerValidate="cusValCantidad_ServerValidate"></asp:CustomValidator>
    &nbsp;<asp:RequiredFieldValidator ID="reqCantidad" runat="server" ControlToValidate="txbCantidad" Display="Dynamic" ErrorMessage="La cantidad es requerida"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbFecha" runat="server" Text="Fecha" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="txbFecha" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
    <br />
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    <br />
    <asp:Label ID="lbExistencias" runat="server" Text="Existencias"></asp:Label>
    <br />
    <asp:TextBox CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="txbExistencias" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/compras.aspx" Text="Cancelar" />
</asp:Content>
