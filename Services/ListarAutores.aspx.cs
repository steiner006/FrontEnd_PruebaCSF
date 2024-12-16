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
    public partial class ListarAutores : Page
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

                    CargarAutores();  // Método para cargar autores en el GridView
                }

            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje de error en el GridView
                gvAutores.EmptyDataText = $"Error: {ex.Message}";
            }
        }

        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    // Obtener el ID del autor de la fila seleccionada
                    int id = Convert.ToInt32(e.CommandArgument);

                    // Llamar al método para eliminar el autor
                    EliminarAutor(id);

                    // Recargar la lista de autores
                    CargarAutores();

                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Autor eliminado correctamente.";
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


        private async void CargarAutores()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/");
                    var response = await client.GetAsync("api/Autores");

                    if (response.IsSuccessStatusCode)
                    {
                        var autores = await response.Content.ReadAsAsync<List<Autor>>();
                        gvAutores.DataSource = autores;
                        gvAutores.DataBind();
                    }
                    else
                    {
                        gvAutores.EmptyDataText = "No existen autores.";
                        gvAutores.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                gvAutores.EmptyDataText = $"Error: {ex.Message}";
                gvAutores.DataBind();
            }
        }




    }
}