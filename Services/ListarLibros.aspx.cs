using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using PruebaCSF_FrontEnd.Models;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class ListarLibros : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    var mensaje = Request.QueryString["mensaje"];
                    if (!string.IsNullOrEmpty(mensaje))
                    {
                        lblMensaje.Text = mensaje;
                    }

                    CargarLibros();  // Método para cargar autores en el GridView
                }

            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje de error en el GridView
                gvLibros.EmptyDataText = $"Error: {ex.Message}";
            }
        }



        protected void gvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    // Obtener el ID del autor de la fila seleccionada
                    int id = Convert.ToInt32(e.CommandArgument);

                    // Llamar al método para eliminar el autor
                    EliminarLibro(id);

                    // Recargar la lista de autores
                    CargarLibros();

                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Libro eliminado correctamente.";
                    lblMensaje.CssClass = "alert alert-success"; // Estilo de éxito
                }
                catch (Exception ex)
                {
                    // En caso de error, mostrar mensaje de error
                    lblMensaje.Text = $"Error al eliminar: {ex.Message}";
                    lblMensaje.CssClass = "alert alert-danger"; // Estilo de error
                }
            }
        }


        private void EliminarLibro(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7062/");
                var response = client.DeleteAsync($"api/Libros/{id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al eliminar el libro.");
                }
            }
        }

        private async void CargarLibros()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/");
                    var response = await client.GetAsync("api/Libros");

                    if (response.IsSuccessStatusCode)
                    {
                        var autores = await response.Content.ReadAsAsync<List<Libro>>();
                        gvLibros.DataSource = autores;
                        gvLibros.DataBind();
                    }
                    else
                    {
                        gvLibros.EmptyDataText = "No existen libros.";
                        gvLibros.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                gvLibros.EmptyDataText = $"Error: {ex.Message}";
                gvLibros.DataBind();
            }
        }



    }
}