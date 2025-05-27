<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="wsProyecto.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/principal/principal.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="REPORTE DE ITEMS" CssClass="tituloContenido"></asp:Label>
    <br /><br />
    
    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" OnClick="ImageButton1_Click" ToolTip="Buscar por ID" />
    <br /><br />
  <asp:GridView ID="GridView1" runat="server" 
    AllowPaging="True" 
    OnPageIndexChanging="GridView1_PageIndexChanging" 
    PageSize="5" 
    CssClass="contenedor-grid tabla-compacta"
    Height="80px" Width="80%">
    
    <AlternatingRowStyle BackColor="#d9e8fb" />
    <HeaderStyle BackColor="#004080" Font-Names="Arial" ForeColor="White" Font-Bold="True" />
    <PagerStyle BackColor="#3366cc" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#003366" />
    <SelectedRowStyle BackColor="#99ccff" Font-Italic="True" />
</asp:GridView>



</asp:Content>
