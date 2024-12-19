using Newtonsoft.Json;
using PruebaCSF_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class CrearLibros : Page
    {
        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (DateTime.TryParseExact(txtFecha.Text, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    
                    var libro = new Libro
                    {
                        Id = 0,
                        Titulo = txtTitulo.Text.Trim(),
                        ISBN = txtISBN.Text.Trim(),
                        AnioPublicacion = fecha.Year,
                        Autores = txtAutores.Text.Trim()
                        
                        
                    };

                    
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7062/");

                        var jsonContent = new StringContent(JsonConvert.SerializeObject(libro), Encoding.UTF8, "application/json");

                        var response = await client.PostAsync("api/Libros", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            
                            Response.Redirect("ListarLibros.aspx");
                        }
                        else
                        {
                            
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            lblMensaje.Text = $"Error: {errorMessage}";
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "La fecha ingresada no es válida. Usa el formato yyyy.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
    }
}