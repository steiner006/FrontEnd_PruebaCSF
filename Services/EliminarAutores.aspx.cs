using System;
using System.Net.Http;
using System.Web.UI;
using PruebaCSF_FrontEnd.Models;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class EliminarAutores : Page
    {
        protected int autorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID del autor desde la URL
                if (int.TryParse(Request.QueryString["id"], out autorId))
                {
                    // Mostrar detalles del autor
                    MostrarAutor(autorId);
                }
                else
                {
                    Response.Redirect("ListarAutores.aspx?mensaje=Error: Autor no encontrado");
                    //lblMensaje.Text = "Error: Autor no encontrado.";
                }
            }
        }

        private void MostrarAutor(int id)
        {
            try
            {
                // Ejemplo de obtener datos desde una API o base de datos
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7062/");  // Tu URL base
                var response = client.GetAsync($"api/Autores/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var autor = response.Content.ReadAsAsync<Autor>().Result;
                    lblAutor.Text = $"{autor.Nombres} {autor.Apellidos}";
                }
                else
                {
                    lblAutor.Text = "No se pudo obtener la información del autor.";
                }
            }
            catch (Exception ex)
            {
                lblAutor.Text = $"Error: {ex.Message}";
            }
        }


        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            // Lógica de eliminación
            int id = Convert.ToInt32(Request.QueryString["id"]);
            EliminarAutor(id);

            // Redirigir con un mensaje
            Response.Redirect("ListarAutores.aspx?mensaje=Autor eliminado correctamente");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir sin eliminar
            Response.Redirect("ListarAutores.aspx?mensaje=El autor no fue eliminado");
        }

        private void EliminarAutor(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7062/");
                var response = client.DeleteAsync($"api/Autores/{id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al eliminar el autor.");
                }
            }
        }
    }
}
