<%@ Page Theme="general" Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="informeCompras.aspx.cs" Inherits="nba.informeCompras" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button class="bg-dark text-light col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12" ID="btnVolver" runat="server" PostBackUrl="~/compras.aspx" Text="Volver" />
    <br /><br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="651px">
        <LocalReport ReportPath="compras.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="nba.DataSet2TableAdapters.comprasVistaTableAdapter"></asp:ObjectDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    
</asp:Content>
