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
                    var client = new ApiClient();
                    var authors = await client.GetAsync<List<Autor>>("api/Autores");
                    gvAutores.DataSource = authors;
                    gvAutores.DataBind();

                    // Verificar si se obtuvieron datos
                    if (authors != null && authors.Count > 0)
                    {
                        gvAutores.DataSource = authors;
                        gvAutores.DataBind();
                    }
                    else
                    {
                        gvAutores.EmptyDataText = "No existen autores";
                    }
                }
                
            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje de error en el GridView
                gvAutores.EmptyDataText = $"Error: {ex.Message}";
            }
        }

        protected void gvAutores_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Obtener el ID del autor desde CommandArgument
                int Id = Convert.ToInt32(e.CommandArgument);

                lblMensaje.Text = $"Eliminando autor con ID: {Id}";
                // Llamar al método para eliminar el autor
                EliminarAutor(Id);
            }
        }


        private async void EliminarAutor(int Id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7062/"); 
                    var response = await client.DeleteAsync($"api/Autores/{Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        CargarAutores();  
                        lblMensaje.Text = "El autor fue eliminado correctamente.";
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        lblMensaje.Text = $"Error al eliminar el autor: {errorMessage}";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
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
                        lblMensaje.Text = "Error al cargar los autores.";
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