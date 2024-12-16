<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="CrearLibros.aspx.cs" Inherits="PruebaCSF_FrontEnd.Services.CrearLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Crear Libros</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="formCreateAuthor" runat="server" class="container">
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
            <h2 class="text-center">Crear Libro</h2>
            <div class="mb-3">
                <label for="lblTitulo" class="form-label">Titulo</label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="lblAutores" class="form-label">Autor</label>
                <asp:TextBox ID="txtAutores" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="lblFecha" class="form-label">Año de Publicación</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" placeholder="yyyy"></asp:TextBox>
                <asp:RegularExpressionValidator 
                    ID="revFecha" 
                    runat="server" 
                    ControlToValidate="txtFecha" 
                    ValidationExpression="^\d{4}$" 
                    ErrorMessage="Por favor, ingresa una fecha en el formato yyyy" 
                    ForeColor="Red" 
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label for="lblISBN" class="form-label">ISBN</label>
                <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>


