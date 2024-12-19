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

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7062/");

                        var jsonContent = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");

                        var response = await client.PostAsync("api/Autores", jsonContent);

                        if (response.IsSuccessStatusCode)
                        {
                            Response.Redirect("ListarAutores.aspx");
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
