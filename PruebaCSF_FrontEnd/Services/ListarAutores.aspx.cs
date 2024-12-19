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

                    CargarAutores();  
                }

            }
            catch (Exception ex)
            {
                gvAutores.EmptyDataText = $"Error: {ex.Message}";
            }
        }

        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);

                    EliminarAutor(id);

                    CargarAutores();

                    lblMensaje.Text = "Autor eliminado correctamente.";
                    lblMensaje.CssClass = "alert alert-success"; 
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = $"Error al eliminar: {ex.Message}";
                    lblMensaje.CssClass = "alert alert-danger"; 
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