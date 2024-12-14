<%@ Page Language="C#" Async="True" AutoEventWireup="true" CodeBehind="ListarAutores.aspx.cs" Inherits="PruebaCSF_FrontEnd.Services.ListarAutores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista de Autores</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function confirmarEliminacion(Id) {
            console.log("Confirmando eliminación de autor con ID: " + Id);
            return confirm("¿Estás seguro de que deseas eliminar este autor con ID: " + Id + "?");
        }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center">Lista de Autores</h2>
            
            
            <asp:GridView ID="gvAutores" runat="server" CssClass="table table-bordered table-striped"
                AutoGenerateColumns="False" EmptyDataText="Autores no encontrados" OnRowDataBound="gvAutores_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditar" runat="server" NavigateUrl='<%# "EditarAutores.aspx?id=" + Eval("Id") %>' Text="Editar" CssClass="btn btn-primary btn-sm"></asp:HyperLink>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>  
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
