using System;
using System.Net.Http;
using System.Web.UI;
using PruebaCSF_FrontEnd.Models;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class EliminarLibros : Page
    {
        protected int libroId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out libroId))
                {
                    MostrarLibro(libroId);
                }
                else
                {
                    Response.Redirect("ListarLibros.aspx?mensaje=Error: Libro no encontrado");
                }
            }
        }

        private void MostrarLibro(int id)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7062/"); 
                var response = client.GetAsync($"api/Libros/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var Libro = response.Content.ReadAsAsync<Libro>().Result;
                    lblTituloAutor.Text = $"{Libro.Titulo} - {Libro.Autores}";
                }
                else
                {
                    lblTituloAutor.Text = "No se pudo obtener la información del Libro.";
                }
            }
            catch (Exception ex)
            {
                lblTituloAutor.Text = $"Error: {ex.Message}";
            }
        }


        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            EliminarLibro(id);

            Response.Redirect("ListarLibros.aspx?mensaje=Libro eliminado correctamente");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarLibros.aspx?mensaje=El Libro no fue eliminado");
        }

        private void EliminarLibro(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7062/");
                var response = client.DeleteAsync($"api/Libros/{id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al eliminar el Libro.");
                }
            }
        }
    }
}
