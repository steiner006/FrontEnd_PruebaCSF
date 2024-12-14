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


