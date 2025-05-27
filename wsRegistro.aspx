<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="wsRegistro.aspx.cs" Inherits="wsProyecto.wsRegistro" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Registro de Alumno</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="container mt-5">
            <div class="card shadow-lg">
                <div class="card-header bg-primary text-white">
                    <h3 class="mb-0"><i class="bi bi-person-plus-fill me-2"></i>Registro de Alumno</h3>
                </div>
                <div class="card-body">
                    <!-- Datos Personales -->
                    <div class="form-section mb-4">
                        <h5 class="text-primary fw-bold mb-3"><i class="bi bi-person-lines-fill"></i> Datos Personales</h5>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Número de Control</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-card-heading"></i></span>
                                    <asp:TextBox ID="txtNumControl" runat="server" CssClass="form-control" placeholder="Número de control" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Carrera</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-book"></i></span>
                                    <asp:TextBox ID="txtCarrera" runat="server" CssClass="form-control" placeholder="Carrera" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="form-label">Nombre(s)</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-person"></i></span>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre(s)" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Apellido Paterno</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-person"></i></span>
                                    <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" placeholder="Apellido paterno" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Apellido Materno</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-person"></i></span>
                                    <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" placeholder="Apellido materno" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Datos de Acceso -->
                    <div class="form-section mb-4">
                        <h5 class="text-primary fw-bold mb-3"><i class="bi bi-shield-lock-fill"></i> Datos de Acceso</h5>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Usuario</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Nombre de usuario" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Correo Electrónico</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-envelope-fill"></i></span>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="correo@ejemplo.com" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Contraseña</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-lock-fill"></i></span>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Confirmar Contraseña</label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-lock-fill"></i></span>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar contraseña" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Información Adicional -->
                    <div class="form-section mb-4">
                        <h5 class="text-primary fw-bold mb-3"><i class="bi bi-info-circle-fill"></i> Información Adicional</h5>
                        <div class="mb-3">
                            <label class="form-label">Ubicación</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
                                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" placeholder="Dirección" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Fotografía</label>
                            <asp:FileUpload ID="fileFoto" runat="server" CssClass="form-control" ClientIDMode="Static" />
                        </div>
                    </div>

                    <!-- Botones -->
                    <div class="d-grid gap-2 mb-3">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-primary btn-lg" OnClick="btnRegistrar_Click" />
                    </div>
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
