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
                    var client = new ApiClient();
                    var libros = await client.GetAsync<List<Libro>>("api/Libros");
                    gvLibros.DataSource = libros;
                    gvLibros.DataBind();

                    // Verificar si se obtuvieron datos
                    if (libros != null && libros.Count > 0)
                    {
                        gvLibros.DataSource = libros;
                        gvLibros.DataBind();
                    }
                    else
                    {
                        gvLibros.EmptyDataText = "No existen libros";
                    }
                }

            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje de error en el GridView
                gvLibros.EmptyDataText = $"Error: {ex.Message}";
            }
        }

        protected void gvLibros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el ID del autor
                int id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id"));

                // Obtener el botón de eliminación en esta fila
                Button btnEliminar = (Button)e.Row.FindControl("btnEliminar");

                // Establecer el atributo OnClientClick con el ID del autor
                btnEliminar.OnClientClick = $"return confirmarEliminacion({id});";
            }
        }

        protected void gvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Obtener el ID del autor desde CommandArgument
                int Id = Convert.ToInt32(e.CommandArgument);

                lblMensaje.Text = $"Eliminando libro con ID: {Id}";
                // Llamar al método para eliminar el autor
                EliminarLibro(Id);
            }
        }


        private async void EliminarLibro(int Id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/");
                    var response = await client.DeleteAsync($"api/Libros/{Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        CargarLibro();
                        lblMensaje.Text = "El libro fue eliminado correctamente.";
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        lblMensaje.Text = $"Error al eliminar el libro: {errorMessage}";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }

        private async void CargarLibro()
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
                        lblMensaje.Text = "Error al cargar los libros.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }



    }
}