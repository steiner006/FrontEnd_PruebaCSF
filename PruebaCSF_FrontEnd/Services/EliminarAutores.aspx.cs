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
                if (int.TryParse(Request.QueryString["id"], out autorId))
                {
                    MostrarAutor(autorId);
                }
                else
                {
                    Response.Redirect("ListarAutores.aspx?mensaje=Error: Autor no encontrado");
                }
            }
        }

        private void MostrarAutor(int id)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7062/");  
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            EliminarAutor(id);

            Response.Redirect("ListarAutores.aspx?mensaje=Autor eliminado correctamente");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
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
