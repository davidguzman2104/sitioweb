<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web3.aspx.cs" Inherits="wsProyecto.Formulario_web3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">    
    <br />
    <asp:Label ID="Label1" runat="server" Text="GESTOR DE ITEMS" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
    <br /><br />

    <table width="70%" border="0">
        <tr>
    <td width="30%">

        <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" Text="Id:"></asp:Label>

    </td>
    <td width="70%">

        <asp:TextBox ID="TextBox6" runat="server" MaxLength="4" Width="209px"></asp:TextBox>
        <asp:ImageButton ID="ImageButtonBuscar" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" 
        OnClick="ImageButtonBuscar_Click" AlternateText="Buscar" Width="25px" Height="25px" />

    </td>
</tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" Text="Nombre:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox1" runat="server" MaxLength="25" Width="209px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" Text="Foto:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox2" runat="server" MaxLength="150" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" Text="Status:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox3" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" Text="Ubicacion:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox4" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" Text="Disponibilidad:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox5" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

            </td>
        </tr>

         <tr>
     <td width="30%">

         <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" Text="No.Control:"></asp:Label>

     </td>
     <td width="70%">

         <asp:TextBox ID="TextBox7" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

     </td>
 </tr>

   <tr>
    <td width="30%">

        <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="Small" Text="Nombre_Alumno:"></asp:Label>

    </td>
    <td width="70%">

        <asp:TextBox ID="TextBox8" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

    </td>
</tr>
  <tr>
            <td colspan="2" align="middle">
                <br />
                <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="Button2_Click" />
                &nbsp;
                <asp:Button ID="Button3" runat="server" Text="Eliminar"  CssClass="btn btn-danger" OnClick="Button3_Click" />
                <br />
            </td>
        </tr>
    </table>

    <br /><br />
</div>

</asp:Content>
