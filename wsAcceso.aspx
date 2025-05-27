<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="wsAcceso.aspx.cs" Inherits="wsProyecto.wsAcceso" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Acceso Principal</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" align="middle">
            <div class="row align-content-center">
                <div class="col-3 col-auto"></div>
                <div class="col-6 col-auto">
                    <table class="table border">
                        <tr>
                            <td colspan="2" align="middle" class="bg-info align-middle">
                                <h3>Acceso Principal</h3>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">
                                <h6>Usuario:</h6>
                            </td>
                            <td width="70%" class="bg-light">
                                <div class="input-group mb-1">
                                    <span class="input-group-text" id="basic-addon1">@</span>
                                    <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" bgcolor="lightblue">
                                <h6>Contraseña:</h6>
                            </td>
                            <td width="70%" class="bg-light">
                                <div class="input-group mb-1">
                                    <span class="input-group-text" id="basic-addon2">@</span>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" aria-label="Password" aria-describedby="basic-addon2"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="middle">
                                <asp:Button ID="btnAcceder" runat="server" Text="Acceder" CssClass="btn btn-primary" OnClick="btnAcceder_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-outline-info" OnClick="btnRegistro_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-3 col-auto"></div>
            </div>
        </div>
    </form>

    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="bootstrap/js/popper.js"></script>
    <script src="bootstrap/js/jquery-3.5.1.min.js"></script>
</body>
</html>