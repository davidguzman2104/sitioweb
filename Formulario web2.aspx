<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web2.aspx" Inherits="wsProyecto.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
        .auto-style2 {
            height: 18px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">    
    <br />
    <asp:Label ID="Label1" runat="server" Text="Gestión de Usuario" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
    <br /><br />

    <table width="70%" border="0">
        <tr>
            <td width="30%">

                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" Text="No.Control:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" Width="209px"></asp:TextBox>

                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" OnClick="ImageButton5_Click" />

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" Text="Nombre:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox2" runat="server" MaxLength="150" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" Text="Apellido Paterno:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox3" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" Text="Apellido Materno:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox4" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">

                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" Text="Usuario:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox5" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%" class="auto-style1">

                <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" Text="Contraseña:"></asp:Label>

            </td>
            <td width="70%" class="auto-style1">

                <asp:TextBox ID="TextBox6" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

            </td>
        </tr>

        <tr>
            <td width="30%">

                <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" Text="Carrera:"></asp:Label>

            </td>
            <td width="70%">

                <asp:TextBox ID="TextBox7" runat="server" MaxLength="200" Width="297px"></asp:TextBox>

            </td>
        </tr>
<tr>
             <td width="30%" class="auto-style2">

     <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" Text="Ubicación:"></asp:Label>

       </td>
      <td width="70%" class="auto-style2">

                <asp:TextBox ID="TextBox8" runat="server" MaxLength="200" Width="297px"></asp:TextBox>

             </td>
        </tr>
        

           <tr>
        <td width="30%">

        <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" Text="Email:"></asp:Label>

        </td>
        <td width="70%">
        <asp:TextBox ID="TextBox9" runat="server" MaxLength="200" Width="297px"></asp:TextBox>

         </td>
         </tr>

                   <tr>
        <td width="30%">

        <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" Text="Foto:"></asp:Label>

        </td>
        <td width="70%">
        <asp:TextBox ID="TextBox10" runat="server" MaxLength="200" Width="297px"></asp:TextBox>

         </td>
         </tr>

        <tr>
            <td colspan="2" align="middle">
                <br />
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