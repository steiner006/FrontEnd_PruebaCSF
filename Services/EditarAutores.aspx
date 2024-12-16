<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="EditarAutores.aspx.cs" Inherits="PruebaCSF_FrontEnd.Services.EditarAutores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Editar Autor</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="formEditAuthor" runat="server" class="container">
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
            <h2 class="text-center">Editar Autor</h2>
            <asp:HiddenField ID="txtId" runat="server" />
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFecha" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                <asp:RegularExpressionValidator 
                    ID="revFecha" 
                    runat="server" 
                    ControlToValidate="txtFecha" 
                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$" 
                    ErrorMessage="Por favor, ingresa una fecha en el formato dd/MM/yyyy" 
                    ForeColor="Red" 
                    Display="Dynamic" />
            </div>
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>
