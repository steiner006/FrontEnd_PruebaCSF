using Newtonsoft.Json;
using PruebaCSF_FrontEnd.Models;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace PruebaCSF_FrontEnd.Services
{
    public partial class CrearAutores : Page
    {
        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    
                    var autor = new Autor
                    {
                        Id = 0,
                        Nombres = txtNombre.Text.Trim(),
                        Apellidos = txtApellido.Text.Trim(),
                        FechaNacimiento = fecha 
                    };

                    // Crear una instancia del cliente HTTP
                    using (var client = new HttpClient())
                    {
                        // Configurar la URL de la API
                        client.BaseAddress = new Uri("https://localhost:7062/");

                        // Convertir el autor a JSON
                        var jsonContent = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");

                        // Enviar el POST a la API
                        var response = await client.PostAsync("api/Autores", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            // Redirigir a la página ListarAutores.aspx después de crear el autor
                            Response.Redirect("ListarAutores.aspx");
                        }
                        else
                        {
                            // Leer el mensaje de error de la API
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            lblMensaje.Text = $"Error: {errorMessage}";
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "La fecha ingresada no es válida. Usa el formato dd/MM/yyyy.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
    }
}
