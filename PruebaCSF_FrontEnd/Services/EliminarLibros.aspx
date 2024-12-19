<%@ Page Language="C#" Async="True" AutoEventWireup="true" CodeBehind="EliminarLibros.aspx.cs" Inherits="PruebaCSF_FrontEnd.Services.EliminarLibros" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eliminar Libro</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container-fluid"> 
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
            <h2 class="text-center">Eliminar Libro</h2>

            
            <asp:Label ID="lblConfirmacion" runat="server" CssClass="alert alert-warning" Text="¿Está seguro de que desea eliminar al libro?"></asp:Label>
            <br /><br /><br />
            
            <asp:Label ID="lblTituloAutor" runat="server" Text="" CssClass="alert alert-info"></asp:Label>
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblAutor" runat="server" Text=""></asp:Label><br />

            
            <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar eliminación" CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>

        
        
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
