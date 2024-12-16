<%@ Page Language="C#" Async="True" AutoEventWireup="true" CodeBehind="EliminarAutores.aspx.cs" Inherits="PruebaCSF_FrontEnd.Services.EliminarAutores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eliminar Autor</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">Prueba Técnica CSF</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Alternar navegación" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/">CSF</a></li>
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/Services/ListarAutores">Autores</a></li>
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/Services/ListarLibros">Libros</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container mt-5">
            <h2 class="text-center">Eliminar Autor</h2>

            <!-- Mensaje de confirmación de eliminación -->
            <asp:Label ID="lblConfirmacion" runat="server" CssClass="alert alert-warning" Text="¿Está seguro de que desea eliminar al autor?"></asp:Label>
            <br /><br /><br />
            <!-- Aquí se mostrarán los detalles del autor que se va a eliminar -->
            <asp:Label ID="lblAutor" runat="server" Text="" CssClass="alert alert-info"></asp:Label>
            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label><br />

            <!-- Botones para confirmar o cancelar -->
            <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar eliminación" CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>

        <!-- Mensaje de error o confirmación -->
        
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
